<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
>
    <xsl:output method="html"/>

    <xsl:template match="/">
      <html>
        <body>
          <h2>Song Base</h2>
          <table border ="1">
            <tr bgcolor ="#00ffff">
              <th>Song</th>
              <th>Album</th>
              <th>BandName</th>
              <th>Genre</th>
              <th>Duration</th>
              <th>ReleaseYear</th>
            </tr>
            <xsl:for-each select="SongDataBase/song">
              <tr bgcolor ="#ffff00">
                <td><xsl:value-of select="@SongName"/></td>
                <td><xsl:value-of select="@Album"/></td>
                <td><xsl:value-of select="@BandName"/></td>
                <td><xsl:value-of select="@Genre"/></td>
                <td><xsl:value-of select="@Duration"/></td>
                <td><xsl:value-of select="@ReleaseYear"/></td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
