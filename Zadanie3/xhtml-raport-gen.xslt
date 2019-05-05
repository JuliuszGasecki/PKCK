<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:output method="xhtml" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"
                doctype-public="-//W3C//DTD XHTML 1.0 Strict//EN" version="1.0" encoding="UTF-8"/>

    <xsl:template name="report" match="/report">
        <html xmlns="http://www.w3.org/1999/xhtml" xml:lang="pl" lang="pl">
            <head>
                <title>Games catalog report</title>
            </head>
            <body>
                <div id="header">
                    <h1>GAMES CATALOG REPORT</h1>
                    <h2>Authors: Juliusz Gąsecki|Bartosz Stempień</h2>
                    <h3> Report generated:
                        <xsl:value-of select="/report/reportInfo"/>
                    </h3>
                </div>
                <div id="allGames">
                    <h2>Games Info</h2>
                    <table width = "100%" border ="3">
                        <tr>
                            <th>title</th>
                            <th>producerName</th>
                            <th>publisherName</th>
                            <th>engineName</th>
                            <th>rating</th>
                            <th>platformName</th>
                            <th>genre</th>
                            <th>price</th>
                            <th>date</th>
                            <th>userScore</th>
                            <th>metaScore</th>
                        </tr>
                        <xsl:for-each select="/report/game">
                            <tr>
                                <xsl:for-each select="*">
                                    <td>
                                        <xsl:value-of select="."/>
                                    </td>
                                </xsl:for-each>
                            </tr>
                        </xsl:for-each>
                    </table>
                </div>
                <div id="statistics">
                    <div id="producersInfo">
                        <h2>Amount of games developed by Producer</h2>
                        <table width = "100%" border ="3">
                            <tr>
                                <th>Producer</th>
                                <th>Amount</th>
                            </tr>
                            <xsl:for-each select="/report/reportStatistics/mostCommonProducers/producersCount">
                                <tr>
                                    <xsl:for-each select="*">
                                        <td>
                                            <xsl:value-of select="."/>
                                        </td>
                                    </xsl:for-each>
                                </tr>
                            </xsl:for-each>
                        </table>
                    </div>
                    <div id="ratingsInfo">
                        <h2>Amount of games with rating</h2>
                        <table width = "100%" border ="3">
                            <tr>
                                <th>Rating</th>
                                <th>Amount</th>
                            </tr>
                            <xsl:for-each select="/report/reportStatistics/mostCommonRating/ratingCount">
                                <tr>
                                    <xsl:for-each select="*">
                                        <td>
                                            <xsl:value-of select="."/>
                                        </td>
                                    </xsl:for-each>
                                </tr>
                            </xsl:for-each>
                        </table>
                    </div>
                    <div id="genresInfo">
                        <h2>Amount of games with specific genres</h2>
                        <table width = "100%" border ="3">
                            <tr>
                                <th>Genre</th>
                                <th>Amount</th>
                            </tr>
                            <xsl:for-each select="/report/reportStatistics/mostCommonGenre/genreCount">
                                <tr>
                                    <xsl:for-each select="*">
                                        <td>
                                            <xsl:value-of select="."/>
                                        </td>
                                    </xsl:for-each>
                                </tr>
                            </xsl:for-each>
                        </table>
                    </div>
                    <div id="otherStatics">
                        <table width = "100%" border ="3">
                            <tr>
                                <th>Amount of games</th>
                                <th>
                                    <xsl:value-of select="/report/reportStatistics/gamesCount" />
                                </th>
                            </tr>
                            <tr>
                                <th>Average price</th>
                                <th>
                                    <xsl:value-of select="/report/reportStatistics/averagePrice" />
                                </th>
                            </tr>
                            <tr>
                                <th>Average user rate</th>
                                <th>
                                    <xsl:value-of select="/report/reportStatistics/averageUserRate" />
                                </th>
                            </tr>
                            <tr>
                                <th>Average metascore</th>
                                <th>
                                    <xsl:value-of select="/report/reportStatistics/averageCrirticRate" />
                                </th>
                            </tr>
                            <tr>
                                <th>The highest price</th>
                                <th>
                                    <xsl:value-of select="/report/reportStatistics/highestPrice" />
                                </th>
                            </tr>
                            <tr>
                                <th>The lowest price</th>
                                <th>
                                    <xsl:value-of select="/report/reportStatistics/lowestPrice" />
                                </th>
                            </tr>
                            <tr>
                                <th>Amount of publishers</th>
                                <th>
                                    <xsl:value-of select="/report/reportStatistics/publishersCount" />
                                </th>
                            </tr>
                            <tr>
                                <th>Amount of producers</th>
                                <th>
                                    <xsl:value-of select="/report/reportStatistics/producersCount" />
                                </th>
                            </tr>

                        </table>

                    </div>

                </div>
                <div id="footer">

                </div>
            </body>

        </html>
    </xsl:template>


</xsl:stylesheet>