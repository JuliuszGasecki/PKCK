<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE svg PUBLIC "-//W3C//DTD SVG 1.1//EN" "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="html"/>

    <xsl:template match="/">
        <svg width="100%" height="100%" xmlns="http://www.w3.org/2000/svg">
            <script type="text/javascript">
                <![CDATA[
                    function onClickButtonGames() {
                        var games = document.getElementById("game");
                        if(games.style.visibility == "visible") {
							games.style.visibility = "hidden";
                        } else {
                            games.style.visibility = "visible";
                        }
                        }

                    function onClickButtonChartsProducers(name) {
                            var producers = document.getElementById("producers");
                            var genres = document.getElementById("genres");
                            var ratings = document.getElementById("ratings");
                            var general = document.getElementById("general");
                                if(producers.style.visibility == "hidden") {
                                    prepareTable("producersTable")
                                    producers.style.visibility = "visible";
                                    genres.style.visibility = "hidden";
                                    ratings.style.visibility = "hidden";
                            }
                            else {
                                boldBiggestValue("producersTable");
                            }
                        }

                    function onClickButtonChartsGenres(name) {
                            var producers = document.getElementById("producers");
                            var genres = document.getElementById("genres");
                            var ratings = document.getElementById("ratings");
                            var general = document.getElementById("general");
                                if(genres.style.visibility == "hidden") {
                                    prepareTable("genresTable")
                                    genres.style.visibility = "visible";
                                    producers.style.visibility = "hidden";
                                    ratings.style.visibility = "hidden";
                            }
                            else {
                            boldBiggestValue("genresTable");
                            }
                        }
                    function onClickButtonChartsRatings(name) {
                            var producers = document.getElementById("producers");
                            var genres = document.getElementById("genres");
                            var ratings = document.getElementById("ratings");
                            var general = document.getElementById("general");
                                if(ratings.style.visibility == "hidden") {
                                    genres.style.visibility = "hidden";
                                    producers.style.visibility = "hidden";
                                    ratings.style.visibility = "visible";
                                    prepareTable("ratingsTable");
                            }
                            else {
                            boldBiggestValue("ratingsTable");
                            }
                        }
                        function boldBiggestValue(table)
                            {
                                var max = 0;
                                var iterMax = [];
                                var min = 10;
                                var iterMin = [];
                                var table = document.getElementById(table);
                                var rows = table.rows;
                                console.log(rows.length);
                                for (i = 1; i < (rows.length); i++) {
                                    if(rows[i].cells[1].innerHTML > max)
                                    {
                                        max = rows[i].cells[1].innerHTML;
                                    }
                                }
                                for (i = 1; i < (rows.length); i++) {
                                    if(rows[i].cells[1].innerHTML == max)
                                    {
                                        iterMax.push(i);
                                    }
                                }
                                for (i = 1; i < (rows.length); i++) {
                                    if(rows[i].cells[1].innerHTML < min)
                                    {
                                        min = rows[i].cells[1].innerHTML;
                                    }
                                }
                                for (i = 1; i < (rows.length); i++) {
                                    if(rows[i].cells[1].innerHTML == min)
                                    {
                                        iterMin.push(i);
                                    }
                                }
                                for(i = 0; i < (iterMin.length); i++)
                                {
                                    rows[iterMin[i]].style.backgroundColor = "#80b3ff";
                                }
                                for(i = 0; i < (iterMax.length); i++)
                                {
                                    rows[iterMax[i]].style.backgroundColor = "#ff8080";
                                }

                            }

                            function prepareTable(table)
                            {
                             var table = document.getElementById(table);
                                var rows = table.rows;
                                console.log(rows.length);
                                for (i = 1; i < (rows.length); i++) {
                                    rows[i].style.backgroundColor = "#bfbfbf";
                                }
                            }
                    ]]>
            </script>
            <defs>
                <filter id="f1" x="0" y="0" width="200%" height="200%">
                    <feOffset result="offOut" in="SourceGraphic" dx="5" dy="5" />
                    <feBlend in="SourceGraphic" in2="offOut" mode="normal" />
                </filter>
            </defs>
            <rect width="100%" height="100%" fill="#bfbfbf"/>
            <text x="40%" y="10%" font-family="sans=serif" fill="#000000" font-size="32">
                Games Catalog statistics
            </text>
            <g  id="games" class="btn" onclick="onClickButtonGames()" cursor="pointer">
                <rect x="45%" y="15%" width="10%" height="10%" fill="white" stroke="black" filter="url(#f1)" />
                <text x="47%" y="20%" fill="black" font-size="20" >Games</text>
            </g>
            <g  id="prodcerStats" class="btn" onclick="onClickButtonChartsProducers(evt)" cursor="pointer">
                <rect x="30%" y="30%" width="10%" height="10%" fill="white" stroke="black" filter="url(#f1)" />
                <text x="32%" y="35%" fill="black" font-size="20" >Producers statistics</text>
            </g>

            <g  id="genreStats" class="btn" onclick="onClickButtonChartsGenres(evt)" cursor="pointer">
                <rect x="45%" y="30%" width="10%" height="10%" fill="white" stroke="black" filter="url(#f1)" />
                <text x="47%" y="35%" fill="black" font-size="20" >Genres statistics</text>
            </g>

            <g  id="ratingStats" class="btn" onclick="onClickButtonChartsRatings(evt)" cursor="pointer">
                <rect x="60%" y="30%" width="10%" height="10%" fill="white" stroke="black" filter="url(#f1)" />
                <text x="62%" y="35%" fill="black" font-size="20" >Ratings statistics</text>
            </g>


            <g id="game" style="visibility: hidden;">
                <rect x="0" y="0" width="20%" height="45%" fill="#737373"/>
                <xsl:element name="text">
                    <xsl:for-each select="report/game">
                        <xsl:element name="tspan">
                            <xsl:attribute name="x">
                                <xsl:text>20</xsl:text>
                            </xsl:attribute>
                            <xsl:attribute name="y">
                                <xsl:value-of select="20+(position()-1)*30"/>
                            </xsl:attribute>
                            <xsl:attribute name="fill">
                                <xsl:text>white</xsl:text>
                            </xsl:attribute>
                            <xsl:attribute name="font-size">
                                <xsl:text>16</xsl:text>
                            </xsl:attribute>
                            <xsl:value-of select="current()/title"/>
                        </xsl:element>
                    </xsl:for-each>
                </xsl:element>
            </g>


            <g id ="producers" style="visibility: visible;">
            <text x="10%" y="55%" font-family="sans=serif" fill="black" font-size="36">
                Amount of games developed by producer
            </text>
            <foreignObject x="10%" y="60%" width="100%" height="50%">
                <body xmlns="http://www.w3.org/1999/xhtml">
                    <table id = "producersTable">
                        <tr>
                            <th width="400">Produer name</th>
                            <th width="400">Amount of games</th>
                            <th width="600">Charts</th>
                        </tr>
                        <xsl:for-each select="/report/reportStatistics/mostCommonProducers/producersCount">
                            <tr onMouseover="this.style.backgroundColor='#ffeecc'" onMouseOut="this.style.backgroundColor='white'">
                                <td>
                                    <xsl:value-of select="current()/producer"/>
                                </td>
                                <td>
                                    <xsl:value-of select="current()/count"/>
                                </td>
                                <td>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="2000" height="18">
                                        <rect x="10px" y="10px" height="{current()/count * 100}" width="{1000}" fill="black" />
                                        <animate attributeName="width" attributeType="XML" begin="0s" dur="2s" from="0" to="{current()/count* 100}" repeatCount="1" fill="freeze" />
                                    </svg>
                                </td>
                            </tr>
                        </xsl:for-each>
                    </table>
                </body>
            </foreignObject>
        </g>

        <g id ="genres" style="visibility: hidden;">
            <text x="10%" y="55%" font-family="sans=serif" fill="black" font-size="36">
                Amount of games with genre
            </text>
            <foreignObject x="10%" y="60%" width="100%" height="50%">
                <body xmlns="http://www.w3.org/1999/xhtml">
                    <table id="genresTable">
                        <tr>
                            <th width="400">Genre name</th>
                            <th width="400">Amount of genres</th>
                            <th width="600">Charts</th>
                        </tr>
                        <xsl:for-each select="/report/reportStatistics/mostCommonGenre/genreCount">
                            <tr onMouseover="this.style.backgroundColor='#ffeecc'" onMouseOut="this.style.backgroundColor='white'">
                                <td>
                                    <xsl:value-of select="current()/genre"/>
                                </td>
                                <td>
                                    <xsl:value-of select="current()/count"/>
                                </td>
                                <td>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="2000" height="18">
                                        <rect x="10px" y="10px" height="{current()/count * 100}" width="{1000}" fill="black" />
                                        <animate attributeName="width" attributeType="XML" begin="0s" dur="2s" from="0" to="{current()/count* 100}" repeatCount="1" fill="freeze" />
                                    </svg>
                                </td>
                            </tr>
                        </xsl:for-each>
                    </table>
                </body>
            </foreignObject>
        </g>
            <g id ="ratings" style="visibility: hidden;">
                <text x="10%" y="55%" font-family="sans=serif" fill="black" font-size="36">
                    Amount of games with rating
                </text>
                <foreignObject x="10%" y="60%" width="100%" height="50%">
                    <body xmlns="http://www.w3.org/1999/xhtml">
                        <table id = "ratingsTable">
                            <tr>
                                <th width="400">Rating name</th>
                                <th width="4s00">Amount of ratings</th>
                                <th width="600">Charts</th>
                            </tr>
                            <xsl:for-each select="/report/reportStatistics/mostCommonRating/ratingCount">
                                <tr onMouseover="this.style.backgroundColor='#ffeecc'" onMouseOut="this.style.backgroundColor='white'">
                                    <td>
                                        <xsl:value-of select="current()/rating"/>
                                    </td>
                                    <td>
                                        <xsl:value-of select="current()/count"/>
                                    </td>
                                    <td>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="2000" height="18">
                                            <rect x="10px" y="10px" height="{current()/count * 100}" width="{1000}" fill="black" />
                                            <animate attributeName="width" attributeType="XML" begin="0s" dur="2s" from="0" to="{current()/count* 100}" repeatCount="1" fill="freeze" />
                                        </svg>
                                    </td>
                                </tr>
                            </xsl:for-each>
                        </table>
                    </body>
                </foreignObject>
            </g>
        </svg>
    </xsl:template>
</xsl:stylesheet>