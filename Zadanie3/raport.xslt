<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:xs="http://www.w3.org/2001/XMLSchema">
    <xsl:output method="xml" version="1.0" encoding="UTF-8"/>

    <xsl:template name="GamesCatalog" match="/GamesCatalog">
        <xsl:element name="report">
            <xsl:call-template name="ReportMetadata"/>
            <xsl:apply-templates select="games"/>
            <xsl:call-template name="ReportStatistics"/>
        </xsl:element>
    </xsl:template>
    <xsl:template name="ReportMetadata">
        <xsl:element name="reportInfo">
            <xsl:value-of select="format-dateTime(current-dateTime(),
                                    '[H01]:[m01] [D01]-[M01]-[Y0001]')"/>
        </xsl:element>
    </xsl:template>
    <xsl:template name="Games" match="games">
        <xsl:apply-templates select="game">
            <xsl:sort select="title"/>
        </xsl:apply-templates>
    </xsl:template>
    <xsl:template name="Game" match="game">
        <xsl:element name="game">
            <xsl:apply-templates select="title"/>
            <xsl:apply-templates select="@producerID"/>
            <xsl:apply-templates select="@publisherID"/>
            <xsl:apply-templates select="@engineID"/>
            <xsl:apply-templates select="@ratingID"/>
            <xsl:apply-templates select="@platformID"/>
            <xsl:apply-templates select="@genreID"/>
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
            <xsl:value-of select="."/>
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


    <xsl:template name="Producer" match="@producerID">
        <xsl:element name="producerName">
            <xsl:variable name="producerID" select="."/>
            <xsl:value-of select="/GamesCatalog/producers/producer[@producerID = $producerID]/companyName"/>
        </xsl:element>
    </xsl:template>

    <xsl:template name="Engine" match="@engineID">
        <xsl:element name="engineName">
            <xsl:variable name="engineID" select="."/>
            <xsl:value-of select="concat( /GamesCatalog/gameEngines/engine[@engineID = $engineID]/name, ' by ' ,
										/GamesCatalog/gameEngines/engine[@engineID = $engineID]/company)"/>
        </xsl:element>
    </xsl:template>

    <xsl:template name="Publisher" match="@publisherID">
        <xsl:element name="publisherName">
            <xsl:variable name="publisherID" select="."/>
            <xsl:value-of select="/GamesCatalog/publishers/publisher[@publisherID = $publisherID]/publisherName"/>
        </xsl:element>
    </xsl:template>

    <xsl:template name="Rating" match="@ratingID">
        <xsl:element name="rating">
            <xsl:variable name="ratingID" select="."/>
            <xsl:value-of select="/GamesCatalog/Ratings/Rating[@ratingID = $ratingID]"/>
        </xsl:element>
    </xsl:template>

    <xsl:template name="Platform" match="@platformID">
        <xsl:element name="platformName">
            <xsl:variable name="platformID" select="."/>
            <xsl:value-of select="/GamesCatalog/platforms/platform[@platformID = $platformID]"/>
        </xsl:element>
    </xsl:template>

    <xsl:template name="Genre" match="@genreID">
        <xsl:element name="genre">
            <xsl:variable name="genreID" select="."/>
            <xsl:value-of select="/GamesCatalog/genres/genre[@genreID = $genreID]"/>
        </xsl:element>
    </xsl:template>


    <xsl:template name="ReportStatistics">
        <xsl:element name="reportStatistics">
            <xsl:call-template name="GamesCount"/>
            <!--<xsl:call-template name="MostCommonGenre" />
            <xsl:call-template name="ThreeTitlesWithBestUserScore" />
            <xsl:call-template name="ThreeTitlesWithBestMetaScore" />-->
            <xsl:call-template name="AveragePrice" />
            <xsl:call-template name="AverageUserRate" />
            <xsl:call-template name="AverageCrirticRate" />
            <xsl:call-template name="HighestPrice" />
            <xsl:call-template name="LowestPrice" />
            <xsl:call-template name="PublishersCount" />
            <xsl:call-template name="ProducersCount" />
            <!--<xsl:call-template name="MostCommonPlatform" />
            <xsl:call-template name="SpecificRatingCount" />-->
        </xsl:element>
    </xsl:template>
    <xsl:template name="GamesCount">
        <xsl:element name="gamesCount">
            <xsl:value-of select="count(/GamesCatalog/games/game)"/>
        </xsl:element>
    </xsl:template>

    <xsl:template name="AveragePrice">
        <xsl:element name="averagePrice">
            <xsl:value-of select="format-number(avg(/GamesCatalog/games/game/premierPrice), '#.##')" />
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
            <xsl:value-of select="max(/GamesCatalog/games/game/*[starts-with(local-name(), 'premierPrice')]/xs:float(.))" />
        </xsl:element>
    </xsl:template>
    <xsl:template name="LowestPrice">
        <xsl:element name="lowestPrice">
            <xsl:value-of select="min(/GamesCatalog/games/game/*[starts-with(local-name(), 'premierPrice')]/xs:float(.))" />
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




</xsl:stylesheet>