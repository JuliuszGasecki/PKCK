<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" version="2.0">
    <xsl:output method="xml" encoding="UTF-8" indent="yes" />
    <xsl:template match="/">
        <fo:root>
            <fo:layout-master-set>
                <fo:simple-page-master master-name="A4" page-height="29cm" page-width="21cm" margin-bottom="2cm" margin-top="1cm" margin-left="1.5cm" margin-right="1.5cm">
                    <fo:region-body/>
                    <fo:region-before extent="3.5cm" />
                    <fo:region-after extent="1.5cm" />
                </fo:simple-page-master>
            </fo:layout-master-set>
            <fo:page-sequence master-reference="A4">
                <fo:flow flow-name="xsl-region-body">
                    <fo:block linefeed-treatment="preserve" text-align="center" font-weight="bold" font-size="22px" space-after="30pt">Games Catalog</fo:block>
                    <fo:block linefeed-treatment="preserve" text-align="center" font-weight="bold" font-size="12px">Authors:</fo:block>
                    <fo:block linefeed-treatment="preserve" text-align="center" font-weight="bold" font-size="10px">Juliusz Gasecki</fo:block>
                    <fo:block linefeed-treatment="preserve" text-align="center" font-weight="bold" font-size="10px">Bartosz Stempien</fo:block>
                    <fo:block linefeed-treatment="preserve" text-align="center" font-weight="bold" font-size="12px">Report was generated:</fo:block>
                        <fo:block text-align="center">
                            <xsl:value-of select="report/reportInfo"/>
                        </fo:block>
                    <fo:block linefeed-treatment="preserve" font-weight="bold" font-size="14px">Games </fo:block>
                    <fo:table table-layout="fixed" border-width="4mm" space-before="10pt" space-after="70pt">
                        <fo:table-column column-width="18mm" />
                        <fo:table-column column-width="18mm" />
                        <fo:table-column column-width="18mm" />
                        <fo:table-column column-width="18mm" />
                        <fo:table-column column-width="17mm" />
                        <fo:table-column column-width="18mm" />
                        <fo:table-column column-width="18mm" />
                        <fo:table-column column-width="18mm" />
                        <fo:table-column column-width="18mm" />
                        <fo:table-column column-width="13mm" />
                        <fo:table-column column-width="13mm" />
                        <fo:table-header text-align="center" background-color="#ccccff">
                            <fo:table-row>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="8px">Title</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="8px">Producer name</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="8px">Publisher name</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="8px">Engine name</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="8px">Rating</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="8px">Platform</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="8px">Price</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="8px">Genre</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="8px">Date</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="8px">User score</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="8px">Meta Score</fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                        </fo:table-header>
                        <fo:table-body>
                            <xsl:for-each select="report/game">
                                <fo:table-row>
                                    <fo:table-cell border="1px solid black" font-size="7px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="title" />
                                        </fo:block>
                                    </fo:table-cell>
                                   <fo:table-cell border="1px solid black" font-size="7px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="producerName" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="1px solid black" font-size="7px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="publisherName" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="1px solid black" font-size="7px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="engineName" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="1px solid black" font-size="7px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="ratingName" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="1px solid black" font-size="7px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="platformName" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="1px solid black" font-size="7px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="genreName" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="1px solid black" font-size="7px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="price" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="1px solid black" font-size="7px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="date" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="1px solid black" font-size="7px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="userScore" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="1px solid black" font-size="7px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="metaScore" />
                                        </fo:block>
                                    </fo:table-cell>
                                </fo:table-row>
                            </xsl:for-each>
                        </fo:table-body>
                    </fo:table>
                    <fo:block linefeed-treatment="preserve" font-weight="bold" font-size="12px">Statistics:</fo:block>
                    <fo:table table-layout="fixed" border-width="2mm" space-before="12pt">
                        <fo:table-column column-width="50%" />
                        <fo:table-column column-width="50%" />
                        <fo:table-header text-align="center" background-color="#ccccff">
                            <fo:table-row>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="12px">Name</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="12px">Value</fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                        </fo:table-header>
                        <fo:table-body>
                            <fo:table-row>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        Number of games
                                    </fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        <xsl:value-of select="report/reportStatistics/gamesCount" />
                                    </fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                            <fo:table-row>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        Average price
                                    </fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        <xsl:value-of select="report/reportStatistics/averagePrice" />
                                    </fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                            <fo:table-row>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        Average of users rate
                                    </fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        <xsl:value-of select="report/reportStatistics/averageUserRate" />
                                    </fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                            <fo:table-row>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        Average of Critic rate
                                    </fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        <xsl:value-of select="report/reportStatistics/averageCrirticRate" />
                                    </fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                            <fo:table-row>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        Highest price
                                    </fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        <xsl:value-of select="report/reportStatistics/highestPrice" />
                                    </fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                            <fo:table-row>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        Lowest price
                                    </fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        <xsl:value-of select="report/reportStatistics/lowestPrice" />
                                    </fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                            <fo:table-row>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        Number of publishers
                                    </fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        <xsl:value-of select="report/reportStatistics/publishersCount" />
                                    </fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                            <fo:table-row>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        Number of producers
                                    </fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black" font-size="12px">
                                    <fo:block text-align="center">
                                        <xsl:value-of select="report/reportStatistics/producersCount" />
                                    </fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                        </fo:table-body>
                    </fo:table>
                    <fo:table table-layout="fixed" border-width="2mm" space-before="12pt">
                        <fo:table-column column-width="50%" />
                        <fo:table-column column-width="50%" />
                        <fo:table-header text-align="center" background-color="#ccccff">
                            <fo:table-row>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="12px">Genre</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="12px">Number of games</fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                        </fo:table-header>
                        <fo:table-body>
                            <xsl:for-each select="report/reportStatistics/mostCommonGenre/genreCount">
                                <fo:table-row>
                                    <fo:table-cell border="1px solid black" font-size="12px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="genre" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="1px solid black" font-size="12px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="count" />
                                        </fo:block>
                                    </fo:table-cell>
                                </fo:table-row>
                            </xsl:for-each>
                        </fo:table-body>
                    </fo:table>
                    <fo:table table-layout="fixed" border-width="2mm" space-before="12pt">
                        <fo:table-column column-width="50%" />
                        <fo:table-column column-width="50%" />
                        <fo:table-header text-align="center" background-color="#ccccff">
                            <fo:table-row>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="12px">Rating</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="12px">Number of games</fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                        </fo:table-header>
                        <fo:table-body>
                            <xsl:for-each select="report/reportStatistics/mostCommonRating/ratingCount">
                                <fo:table-row>
                                    <fo:table-cell border="1px solid black" font-size="12px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="rating" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="1px solid black" font-size="12px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="count" />
                                        </fo:block>
                                    </fo:table-cell>
                                </fo:table-row>
                            </xsl:for-each>
                        </fo:table-body>
                    </fo:table>
                    <fo:table table-layout="fixed" border-width="2mm" space-before="10pt">
                        <fo:table-column column-width="50%" />
                        <fo:table-column column-width="50%" />
                        <fo:table-header text-align="center" background-color="#ccccff">
                            <fo:table-row>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="12px">Producer name</fo:block>
                                </fo:table-cell>
                                <fo:table-cell border="1px solid black">
                                    <fo:block text-align="center" font-weight="bold" width="30mm" font-size="12px">Number of games</fo:block>
                                </fo:table-cell>
                            </fo:table-row>
                        </fo:table-header>
                        <fo:table-body>
                            <xsl:for-each select="report/reportStatistics/mostCommonProducers/producersCount">
                                <fo:table-row>
                                    <fo:table-cell border="2px solid black" font-size="12px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="producer" />
                                        </fo:block>
                                    </fo:table-cell>
                                    <fo:table-cell border="2px solid black" font-size="12px">
                                        <fo:block text-align="center">
                                            <xsl:value-of select="count" />
                                        </fo:block>
                                    </fo:table-cell>
                                </fo:table-row>
                            </xsl:for-each>
                        </fo:table-body>
                    </fo:table>
                </fo:flow>
            </fo:page-sequence>
        </fo:root>
    </xsl:template>
</xsl:stylesheet>