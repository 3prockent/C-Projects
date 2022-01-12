using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace LabExcel
{
    public class Table
    {
        private const int defaultCol = 35;
        private const int defaultRow = 10;
        public int colCount;
        public int rowCount;
        public static List<List<Cell>> grid = new List<List<Cell>>();
        public Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public Table()
        {
            setTable(defaultCol, defaultRow);
        }
        public Table(int col, int row)
        {
            setTable(col, row);
        }
        public void setTable(int col, int row)
        {
            Clear();
            colCount = col;
            rowCount = row;
            for (int i = 0; i < rowCount; i++)
            {
                var newRow = new List<Cell>();
                for (int j = 0; j < colCount; j++)
                {
                    newRow.Add(new Cell(i, j));
                    dictionary.Add(newRow.Last().getName(), "");
                }
                grid.Add(newRow);
            }
        } //init table by 2 param
        public void Clear()
        {
            foreach (List<Cell> list in grid)
                list.Clear();
            grid.Clear();
            dictionary.Clear();
            rowCount = 0;
            colCount = 0;
        }
        public string Calculate(string expression)
        {
            string res = null;
            try
            {
                res = (LabCalculator.Calculator.Evaluate(expression)).ToString();
                if (res == "∞")
                    res = "Division by zero error";
                return res;
            }
            catch (Exception)
            {
                return "Error";
            }
        }
        public void changeCellWithAllPointers(int row, int col, string expression, System.Windows.Forms.DataGridView dataGridView1) //refresh cell value with check loops(Main func)
        {
            var currCell = grid[row][col];
            currCell.deletePointesAndReferences();
            currCell.expression = expression;
            currCell.new_referencesFromThis.Clear();

            if (expression != "")
            {
                if (expression[0] != '=')  //expression not formula
                {
                    currCell.value = expression;
                    dictionary[this.fullName(row, col)] = expression;
                    foreach (Cell cell in currCell.pointersToThis)
                    {
                        refreshCellAndPointers(cell, dataGridView1);
                    }
                    return;
                }
            }  //expression formula
            string new_expression = convertReferences(row, col, expression);
            if (new_expression != "")
                new_expression = new_expression.Remove(0, 1);

            if (!currCell.checkLoop(currCell.new_referencesFromThis))  //check new references for loop 
            {
                System.Windows.Forms.MessageBox.Show("There is a loop! Change the expression");
                currCell.expression = "";
                currCell.value = "";
                dataGridView1[col, row].Value = "0";
                return;
            }
            //new_references without loops
            currCell.addPointersAndReferences();
            string val = Calculate(new_expression).ToString(); //calculate ready expression

            if (val == "Error")  //cannot calculate
            {
                System.Windows.Forms.MessageBox.Show("Error in cell " + currCell.getName());
                currCell.expression = "";
                currCell.value = "0";
                dataGridView1[currCell.column, currCell.row].Value = "0";
                return;
            }
            currCell.value = val;
            dictionary[fullName(row, col)] = val;
            foreach (Cell cell in currCell.pointersToThis)   //refresh all cells which has formula with currCell
                refreshCellAndPointers(cell, dataGridView1);

        }
        private string fullName(int row, int col)
        {
            Cell cell = new Cell(row, col);
            return cell.getName();
        }
        public bool refreshCellAndPointers(Cell cell, System.Windows.Forms.DataGridView dataGridView1) //refresh cell
        {
            cell.new_referencesFromThis.Clear();
            string new_expression = convertReferences(cell.row, cell.column, cell.expression); //expression without Cell Names
            new_expression = new_expression.Remove(0, 1); //remove '='
            string Value = Calculate(new_expression).ToString(); //calculate ready expression

            if (Value == "Error")
            {
                System.Windows.Forms.MessageBox.Show("Error in cell " + cell.getName());
                cell.expression = "";
                cell.value = "0";
                dataGridView1[cell.column, cell.row].Value = "0";
                return false;
            }
            grid[cell.row][cell.column].value = Value;
            dictionary[fullName(cell.row, cell.column)] = Value;
            dataGridView1[cell.column, cell.row].Value = Value;

            foreach (Cell point in cell.pointersToThis)  //refresh all cells which points on current
            {
                if (!refreshCellAndPointers(point, dataGridView1))
                    return false;
            }
            return true;
        }

        private void refreshReferences()  //refresh only refs from each cell in all table
        {
            foreach (List<Cell> list in grid)
            {
                foreach (Cell cell in list)
                {
                    if (cell.referencesFromThis != null)
                        cell.referencesFromThis.Clear();
                    if (cell.new_referencesFromThis != null)
                        cell.new_referencesFromThis.Clear();
                    if (cell.expression == "")
                        continue;
                    string new_expression = cell.expression;
                    if (cell.expression[0] == '=') //has formula
                    {
                        new_expression = convertReferences(cell.row, cell.column, cell.expression);
                        cell.referencesFromThis.AddRange(cell.new_referencesFromThis);
                    }
                }
            }
        }
        private string convertReferences(int row, int col, string expr)  // 5+4*AA1-->5+4*('Value of AA1) and add references
        {
            string cellNamePattern = @"[A-Z]+[0-9]+";
            Regex regex = new Regex(cellNamePattern, RegexOptions.IgnoreCase);
            var nums = new Tuple<int, int>(0, 0);

            foreach (Match match in regex.Matches(expr))
            {
                if (dictionary.ContainsKey(match.Value))  //addReference
                {
                    nums = _26BasedSystem.From26System(match.Value);
                    grid[row][col].new_referencesFromThis.Add(grid[nums.Item1][nums.Item2]);
                }
            }
            MatchEvaluator evaluator = new MatchEvaluator(referenceToValue);
            string new_expression = regex.Replace(expr, evaluator);
            return new_expression;
        }
        private string referenceToValue(Match m)   //Evaluator for converting
        {
            if (dictionary.ContainsKey(m.Value))
            {
                if (dictionary[m.Value] == "")
                    return "0";
                else
                    return dictionary[m.Value];
            }
            return m.Value;
        }

        public void AddRow(System.Windows.Forms.DataGridView dataGridView1)
        {
            List<Cell> newRow = new List<Cell>();
            for (int i = 0; i < colCount; i++)
            {
                newRow.Add(new Cell(rowCount, i));
                dictionary.Add(newRow.Last().getName(), "");
            }
            grid.Add(newRow);
            refreshReferences();
            rowCount++;
        }
        public void AddCol(System.Windows.Forms.DataGridView dataGridView1)
        {
            for (int i = 0; i < rowCount; i++)
            {
                grid[i].Add(new Cell(i, colCount));
                dictionary.Add(grid[i].Last().getName(), "");
            }
            refreshReferences();
            colCount++;
        }
        public bool DeleteRow(DataGridView dataGridView1)
        {
            List<Cell> lastRowRef = new List<Cell>(); //Cells that have references on the delete row
            List<Cell> notEmptyCells = new List<Cell>();
            if (rowCount == 0)
                return false;
            int curCount = rowCount - 1;
            for (int i = 0; i < colCount; i++)
            {
                string name = fullName(curCount, i);
                if (dictionary[name] != "0" && dictionary[name] != "" && dictionary[name] != " ")
                    notEmptyCells.Add(grid[curCount][i]);
                if (grid[curCount][i].pointersToThis.Count != 0)  //select cells that points to deleted cell
                    lastRowRef.AddRange(grid[curCount][i].pointersToThis);
            }

            if (lastRowRef.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";
                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are not empty cells: ";
                    foreach (Cell cell in notEmptyCells)
                        errorMessage += string.Join(";", cell.getName());
                    errorMessage += "\n";
                }
                if (lastRowRef.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current Row:\n";
                    foreach (Cell cell in lastRowRef)
                        errorMessage += string.Join(";", cell.getName());
                }
                errorMessage += "\nAre you sure want to delete this column?";
                System.Windows.Forms.DialogResult res = MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                    return false;
            }
            for (int i = 0; i < colCount; i++)
            {
                string name = fullName(curCount,i);
                dictionary.Remove(name);
            }
            foreach (Cell cell in notEmptyCells)
            {
                if (cell.referencesFromThis != null)
                    foreach (Cell reference in cell.referencesFromThis)
                        reference.pointersToThis.Remove(cell);
            }
            
            foreach (Cell cell in lastRowRef)
            {
                if(cell.row != curCount)    
                    refreshCellAndPointers(cell, dataGridView1);
            }
            grid.RemoveAt(curCount);
            rowCount--;
            return true;
        }
        public bool DeleteColumn(DataGridView dataGridView1)
        {
            List<Cell> lastColRef = new List<Cell>(); //Cells that have references on the delete column
            List<Cell> notEmptyCells = new List<Cell>();
            if (colCount == 1)
                return false;
            int curCount = colCount - 1;
            for (int i = 0; i < rowCount; i++)
            {
                string name = fullName(i, curCount);
                if (dictionary[name] != "0" && dictionary[name] != "" && dictionary[name] != " ")
                    notEmptyCells.Add(grid[i][curCount]);
                if (grid[i][curCount].pointersToThis.Count != 0)  //select cells that points to deleted cell
                    lastColRef.AddRange(grid[i][curCount].pointersToThis);
            }

            if (lastColRef.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";
                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are not empty cells: ";
                    foreach (Cell cell in lastColRef)
                        errorMessage += string.Join(";", cell.getName());
                    errorMessage += "\n";
                }
                if (lastColRef.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current column:\n";
                    foreach (Cell cell in lastColRef)
                        errorMessage += string.Join(";", cell.getName());
                }
                errorMessage += "\nAre you sure want to delete this column?";
                System.Windows.Forms.DialogResult res = MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                    return false;
            }
            for (int i = 0; i < rowCount; i++)
            {
                string name = fullName(i, curCount);
                dictionary.Remove(name);
            }
            foreach (Cell cell in notEmptyCells)
            {
                if (cell.referencesFromThis != null)
                {
                    foreach (Cell reference in cell.referencesFromThis)
                        reference.pointersToThis.Remove(cell);
                }
            }
            foreach (Cell cell in lastColRef)
                refreshCellAndPointers(cell, dataGridView1);
            for (int i = 0; i < rowCount; i++)
                grid[i].RemoveAt(curCount);
            colCount--;
            return true;

        }

        public void Save(StreamWriter sw)
        {
            sw.WriteLine(rowCount);
            sw.WriteLine(colCount);     

            foreach (List<Cell> list in grid)
            {
                foreach (Cell cell in list)
                {
                    sw.WriteLine(cell.getName());
                    sw.WriteLine(cell.expression);
                    sw.WriteLine(cell.value);
                    if (cell.referencesFromThis == null)
                        sw.WriteLine("0");
                    else
                    {
                        sw.WriteLine(cell.referencesFromThis.Count);
                        foreach (Cell refCell in cell.referencesFromThis)
                            sw.WriteLine(refCell.getName());
                    }
                    if (cell.pointersToThis == null)
                        sw.WriteLine("0");
                    else
                    {
                        sw.WriteLine(cell.pointersToThis.Count);
                        foreach (Cell pointCell in cell.pointersToThis)
                            sw.WriteLine(pointCell.getName());
                    }
                }
            }
        }
        public void Open(int row, int column, StreamReader sr, DataGridView dataGridView1)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    string index = sr.ReadLine();
                    string expression = sr.ReadLine();
                    string value = sr.ReadLine();

                    if (expression != "")
                        dictionary[index] = value;
                    else
                        dictionary[index] = "";

                    int refCount = Convert.ToInt32(sr.ReadLine());
                    List<Cell> newRef = new List<Cell>();
                    string refer;
                    for (int k = 0; k < refCount; k++)
                    {
                        refer = sr.ReadLine();
                        int curRow = _26BasedSystem.From26System(refer).Item1;
                        int curCol = _26BasedSystem.From26System(refer).Item2;

                        if (curRow < rowCount && curCol < colCount)
                            newRef.Add(grid[curRow][curCol]);
                    }

                    int pointCount = Convert.ToInt32(sr.ReadLine());
                    List<Cell> newPoint = new List<Cell>();
                    string point;
                    for (int k = 0; k < pointCount; k++)
                    {
                        point = sr.ReadLine();
                        int curRow = _26BasedSystem.From26System(point).Item1;
                        int curCol = _26BasedSystem.From26System(point).Item2;
                        newPoint.Add(grid[curRow][curCol]);
                    }
                    grid[i][j].setCell(expression, value, newRef, newPoint);
                    int Col = grid[i][j].column;
                    int Row = grid[i][j].row;
                    dataGridView1[Col, Row].Value = dictionary[index];
                }
            }
        }


    }

    public class Cell
    {
        public string expression { get; set; }
        public string value { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        string name { get; set; }

        public List<Cell> pointersToThis = new List<Cell>();
        public List<Cell> referencesFromThis = new List<Cell>();
        public List<Cell> new_referencesFromThis = new List<Cell>();


        public Cell(int row, int column)
        {
            this.row = row;
            this.column = column;
            name = _26BasedSystem.To26System(column) + row.ToString();
            value = "0";
            expression = "";
        }

        public void setCell(string expression, string value, List<Cell> references, List<Cell> pointers)
        {
            this.value = value;
            this.expression = expression;
            this.referencesFromThis.Clear();
            this.referencesFromThis.AddRange(references);
            this.pointersToThis.Clear();
            this.pointersToThis.AddRange(pointers);
        }

        public bool checkLoop(List<Cell> list)  //??
        {
            foreach (Cell cell in list)
            {
                if (cell.name == name)
                    return false;
            }
            foreach (Cell point in pointersToThis)
            {
                foreach (Cell cell in list)
                {
                    if (cell.name == point.name)
                        return false;
                }
                if (!point.checkLoop(list))
                    return false;
            }
            return true;

        }

        public void addPointersAndReferences()
        {
            foreach (Cell point in new_referencesFromThis)
            {
                point.pointersToThis.Add(this);
            }
            referencesFromThis = new_referencesFromThis;
        }

        public void deletePointesAndReferences()
        {
            if (referencesFromThis != null)
            {
                foreach (Cell point in referencesFromThis)
                {
                    point.pointersToThis.Remove(this);
                }
                referencesFromThis = null;
            }
        }
        public string getName()
        {
            return name;
        }
    }
}