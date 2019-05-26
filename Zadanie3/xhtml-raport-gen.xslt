<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:output method="xhtml" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"
                doctype-public="-//W3C//DTD XHTML 1.0 Strict//EN" version="1.0" encoding="UTF-8"/>

    <xsl:template name="report" match="/report">
        <html xmlns="http://www.w3.org/1999/xhtml" xml:lang="pl" lang="pl">
            <head>
                <title>Games catalog report</title>
                <style>
                    table {
                    border-collapse: collapse;
                    width: 100%;
                    border: 1px;
                    }

                    th, td {
                    text-align: left;
                    padding: 8px;
                    }

                    table, th, td {
                    border: 1px solid black;
                    }

                    tr:nth-child(even) {background-color: #f2f2f2;}

                    #header {
                        text-align: center;
                    }
                </style>
            </head>
            <body>
                <div id="header">
                    <h1>GAMES CATALOG REPORT</h1>
                    <h2>Authors: Juliusz Gąsecki Bartosz Stempień</h2>
                    <h3> Report generated:
                        <xsl:value-of select="/report/reportInfo"/>
                    </h3>
                </div>
                <div id="allGames">
                    <h2>Games Info</h2>
                    <table>
                        <tr>
                            <th>Title</th>
                            <th>Producer Name</th>
                            <th>Publisher Name</th>
                            <th>Engine Name</th>
                            <th>Rating</th>
                            <th>Platform Name</th>
                            <th>Genre</th>
                            <th>Price</th>
                            <th>Date</th>
                            <th>User Score</th>
                            <th>Meta Score</th>
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
                        <table>
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
                        <table>
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
                        <table>
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
                        <h2>Statistics</h2>
                        <table>
                            <tr>
                                <th>Name of statistic</th>
                                <th>Values</th>
                            </tr>
                            <tr>
                                <td>Amount of games</td>
                                <td>
                                    <xsl:value-of select="/report/reportStatistics/gamesCount" />
                                </td>
                            </tr>
                            <tr>
                                <td>Average price</td>
                                <td>
                                    <xsl:value-of select="/report/reportStatistics/averagePrice" />
                                </td>
                            </tr>
                            <tr>
                                <td>Average User Rate</td>
                                <td>
                                    <xsl:value-of select="/report/reportStatistics/averageUserRate" />
                                </td>
                            </tr>
                            <tr>
                                <td>Average Metascore</td>
                                <td>
                                    <xsl:value-of select="/report/reportStatistics/averageCrirticRate" />
                                </td>
                            </tr>
                            <tr>
                                <td>The Highest Price</td>
                                <td>
                                    <xsl:value-of select="/report/reportStatistics/highestPrice" />
                                </td>
                            </tr>
                            <tr>
                                <td>The Lowest Price</td>
                                <td>
                                    <xsl:value-of select="/report/reportStatistics/lowestPrice" />
                                </td>
                            </tr>
                            <tr>
                                <td>Amount of Publishers</td>
                                <td>
                                    <xsl:value-of select="/report/reportStatistics/publishersCount" />
                                </td>
                            </tr>
                            <tr>
                                <td>Amount of Producers</td>
                                <td>
                                    <xsl:value-of select="/report/reportStatistics/producersCount" />
                                </td>
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