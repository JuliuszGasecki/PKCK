<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:xs="http://www.w3.org/2001/XMLSchema">
    <xsl:output method="xml" version="1.0" encoding="UTF-8"/>

    <xsl:key name="producerKey" match="producer" use="@producerID"/>
    <xsl:key name="publisherKey" match="publisher" use="@publisherID"/>
    <xsl:key name="engineKey" match="engine" use="@engineID"/>
    <xsl:key name="ratingKey" match="Rating" use="@ratingID"/>
    <xsl:key name="platformKey" match="platform" use="@platformID"/>
    <xsl:key name="genreKey" match="genre" use="@genreID"/>

    <xsl:template name="GamesCatalog" match="/GamesCatalog">
        <xsl:element name="report">
            <xsl:call-template name="ReportMetadata"/>
            <xsl:apply-templates select="games"/>
            <xsl:call-template name="ReportStatistics"/>
        </xsl:element>
    </xsl:template>
    <xsl:template name="ReportMetadata">
        <xsl:element name="reportInfo">
            <xsl:value-of select="format-dateTime(current-dateTime(),'[H01]:[m01] [D01]-[M01]-[Y0001]')"/>
        </xsl:element>
    </xsl:template>
    <xsl:template name="Games" match="games">
        <xsl:apply-templates select="game">
            <xsl:sort select="metariticRate/metascore" order="descending"/>
        </xsl:apply-templates>
    </xsl:template>
    <xsl:template name="Game" match="game">
        <xsl:element name="game">
            <xsl:apply-templates select="title"/>
            <xsl:element name="producerName">
                <xsl:value-of select="key('producerKey', @producerID)/companyName" />
            </xsl:element>
            <xsl:element name="publisherName">
                <xsl:value-of select="key('publisherKey', @publisherID)/publisherName" />
            </xsl:element>
            <xsl:element name="engineName">
                <xsl:value-of select="key('engineKey', @engineID)/name" />
            </xsl:element>
            <xsl:element name="ratingName">
                <xsl:value-of select="key('ratingKey', @ratingID)" />
            </xsl:element>
            <xsl:element name="platformName">
                <xsl:value-of select="key('platformKey', @platformID)" />
            </xsl:element>
            <xsl:element name="genreName">
                <xsl:value-of select="key('genreKey', @genreID)" />
            </xsl:element>
            <xsl:apply-templates select="premierPrice"/>
            <xsl:apply-templates select="premierDate"/>
            <xsl:apply-templates select="metariticRate"/>
        </xsl:element>
    </xsl:template>


    <xsl:template name="Title" match="title">
        <xsl:element name="title">
            <xsl:value-of select="."/>
        </xsl:element>
    </xsl:template>
    <xsl:template name="Price" match="premierPrice">
        <xsl:element name="price">
            <xsl:value-of select="concat(., ' ' , @currency)"/>
        </xsl:element>
    </xsl:template>

    <xsl:template name="Date" match="premierDate">
        <xsl:element name="date">
            <xsl:value-of select="."/>
        </xsl:element>
    </xsl:template>

    <xsl:template name="MetariticRate" match="metariticRate">
        <xsl:element name="userScore">
            <xsl:value-of select="userScore"/>
        </xsl:element>
        <xsl:element name="metaScore">
            <xsl:value-of select="metascore"/>
        </xsl:element>
    </xsl:template>

    <xsl:template name="ReportStatistics">
        <xsl:element name="reportStatistics">
            <xsl:call-template name="GamesCount"/>
            <xsl:call-template name="MostCommonGenre" />
            <xsl:call-template name="MostCommonRating" />
            <xsl:call-template name="MostCommonProducers" />
            <xsl:call-template name="AveragePrice" />
            <xsl:call-template name="AverageUserRate" />
            <xsl:call-template name="AverageCrirticRate" />
            <xsl:call-template name="HighestPrice" />
            <xsl:call-template name="LowestPrice" />
            <xsl:call-template name="PublishersCount" />
            <xsl:call-template name="ProducersCount" />
        </xsl:element>
    </xsl:template>
    <xsl:template name="GamesCount">
        <xsl:element name="gamesCount">
            <xsl:value-of select="count(/GamesCatalog/games/game)"/>
        </xsl:element>
    </xsl:template>

    <xsl:template name="AveragePrice">
        <xsl:element name="averagePrice">
            <xsl:value-of select="concat(format-number(avg(/GamesCatalog/games/game/premierPrice), '#.##'), ' PLN')" />
        </xsl:element>
    </xsl:template>
    <xsl:template name="AverageUserRate">
        <xsl:element name="averageUserRate">
            <xsl:value-of select="format-number(avg(/GamesCatalog/games/game/metariticRate/userScore), '#.##')" />
        </xsl:element>
    </xsl:template>
    <xsl:template name="AverageCrirticRate">
        <xsl:element name="averageCrirticRate">
            <xsl:value-of select="format-number(avg(/GamesCatalog/games/game/metariticRate/metascore), '#.##')" />
        </xsl:element>
    </xsl:template>
    <xsl:template name="HighestPrice">
        <xsl:element name="highestPrice">
            <xsl:variable name="currnecy" select="/GamesCatalog/games/game/premierPrice[. =max(/GamesCatalog/games/game/*[starts-with(local-name(), 'premierPrice')])]/@currency" />
            <xsl:value-of select="concat(max(/GamesCatalog/games/game/*[starts-with(local-name(), 'premierPrice')]/xs:float(.)), ' ', $currnecy[1])" />
        </xsl:element>
    </xsl:template>
    <xsl:template name="LowestPrice">
        <xsl:element name="lowestPrice">
            <xsl:value-of select="concat (min(/GamesCatalog/games/game/*[starts-with(local-name(), 'premierPrice')]/xs:float(.)), ' ', /GamesCatalog/games/game/premierPrice[. =min(/GamesCatalog/games/game/*[starts-with(local-name(), 'premierPrice')])]/@currency)" />
        </xsl:element>
    </xsl:template>
    <xsl:template name="PublishersCount">
        <xsl:element name="publishersCount">
            <xsl:value-of select="count(/GamesCatalog/publishers/publisher)" />
        </xsl:element>
    </xsl:template>
    <xsl:template name="ProducersCount">
        <xsl:element name="producersCount">
            <xsl:value-of select="count(/GamesCatalog/producers/producer)" />
        </xsl:element>
    </xsl:template>

    <xsl:template name="MostCommonGenre">
        <xsl:element name="mostCommonGenre">
            <xsl:for-each select="/GamesCatalog/genres/genre">
                <xsl:sort select="genre"/>
                <xsl:variable name="genreID" select="@genreID" />
                <xsl:variable name="gamesCount" select="count(/GamesCatalog/games/game[@genreID = $genreID])" />
                <xsl:element name="genreCount">
                    <xsl:element name="genre">
                        <xsl:value-of select="/GamesCatalog/genres/genre[@genreID = $genreID]"/>
                    </xsl:element>
                    <xsl:element name="count">
                        <xsl:value-of select="$gamesCount" />
                    </xsl:element>
                </xsl:element>
            </xsl:for-each>
        </xsl:element>
    </xsl:template>

    <xsl:template name="MostCommonRating">
        <xsl:element name="mostCommonRating">
            <xsl:for-each select="/GamesCatalog/Ratings/Rating">
                <xsl:sort select="Rating"/>
                <xsl:variable name="ratingID" select="@ratingID" />
                <xsl:variable name="gamesCount" select="count(/GamesCatalog/games/game[@ratingID = $ratingID])" />
                <xsl:element name="ratingCount">
                    <xsl:element name="rating">
                        <xsl:value-of select="/GamesCatalog/Ratings/Rating[@ratingID = $ratingID]"/>
                    </xsl:element>
                    <xsl:element name="count">
                        <xsl:value-of select="$gamesCount" />
                    </xsl:element>
                </xsl:element>
            </xsl:for-each>
        </xsl:element>
    </xsl:template>

    <xsl:template name="MostCommonProducers">
        <xsl:element name="mostCommonProducers">
            <xsl:for-each select="/GamesCatalog/producers/producer">
                <xsl:sort select="producer"/>
                <xsl:variable name="producerID" select="@producerID" />
                <xsl:variable name="gamesCount" select="count(/GamesCatalog/games/game[@producerID = $producerID])" />
                <xsl:element name="producersCount">
                    <xsl:element name="producer">
                        <xsl:value-of select="/GamesCatalog/producers/producer[@producerID = $producerID]/companyName"/>
                    </xsl:element>
                    <xsl:element name="count">
                        <xsl:value-of select="$gamesCount" />
                    </xsl:element>
                </xsl:element>
            </xsl:for-each>
        </xsl:element>
    </xsl:template>



</xsl:stylesheet>