<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="text" indent="yes" />

    <xsl:template match="/">
        <xsl:text>Games Catalog&#xA;</xsl:text>
        <xsl:text>Authors:&#xA;</xsl:text>
        <xsl:text>Juliusz Gąsecki i Bartosz Stempień&#xA;</xsl:text>

        <xsl:text>Raport wygenerowania:</xsl:text>
        <xsl:call-template name="info"/>
        <xsl:text>Games:&#xA;</xsl:text>
        <xsl:call-template name="game"/>
        <xsl:text>Statistics:&#xA;</xsl:text>
        <xsl:apply-templates select="/report/reportStatistics"/>
    </xsl:template>

    <xsl:template name="info">
        <xsl:text>&#xA;Dnia</xsl:text>
        <xsl:value-of select="substring((concat(' ',/report/reportInfo)),7, 50)" />
        <xsl:text>&#xA;O godzinie</xsl:text>
        <xsl:value-of select="substring((concat(' ',/report/reportInfo)),1, 6)" />
        <xsl:text>&#xA;</xsl:text>
    </xsl:template>

    <xsl:template name="game">
        <xsl:for-each select="report/game">
            <xsl:text>Title:</xsl:text>
            <xsl:value-of select="concat(' ',title)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Producer:</xsl:text>
            <xsl:value-of select="concat(' ',producerName)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Publisher:</xsl:text>
            <xsl:value-of select="concat(' ',publisherName)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Engine:</xsl:text>
            <xsl:value-of select="concat( ' ',engineName)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Rating:</xsl:text>
            <xsl:value-of select="concat(' ',ratingName)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Platform:</xsl:text>
            <xsl:value-of select="concat(' ',platformName)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Genre:</xsl:text>
            <xsl:value-of select="concat(' ',genreName)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Price:</xsl:text>
            <xsl:value-of select="concat(' ',price)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Date:</xsl:text>
            <xsl:value-of select="concat(' ',date)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>User Score:</xsl:text>
            <xsl:value-of select="concat(' ',userScore)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Meta Score:</xsl:text>
            <xsl:value-of select="concat(' ',metaScore)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>&#xA;</xsl:text>
        </xsl:for-each>
    </xsl:template>
    <xsl:template name="GamesCatalog" match="/report/reportStatistics">
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>General:&#xA;</xsl:text>
        <xsl:text>Amount of games:</xsl:text>
        <xsl:value-of select="concat(' ',gamesCount)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Average Price:</xsl:text>
        <xsl:value-of select="concat(' ',averagePrice)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Average users rate:</xsl:text>
        <xsl:value-of select="concat(' ',averageUserRate)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Average critics rate:</xsl:text>
        <xsl:value-of select="concat(' ',averageCrirticRate)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Highest price:</xsl:text>
        <xsl:value-of select="concat(' ',highestPrice)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Lowest price:</xsl:text>
        <xsl:value-of select="concat(' ',lowestPrice)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Amount of publishers:</xsl:text>
        <xsl:value-of select="concat(' ',publishersCount)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Amount of producers:</xsl:text>
        <xsl:value-of select="concat(' ',producersCount)" />
        <xsl:text>&#xA;</xsl:text>

        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Genre statistics:&#xA;</xsl:text>
        <xsl:apply-templates select="mostCommonGenre"/>
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Rating statistics:&#xA;</xsl:text>
        <xsl:apply-templates select="mostCommonRating"/>
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Producers statistics:&#xA;</xsl:text>
        <xsl:apply-templates select="mostCommonProducers"/>
    </xsl:template>
    <xsl:template name="mostCommongenres" match="/report/reportStatistics/mostCommonGenre">
        <xsl:for-each select="genreCount">
            <xsl:value-of select="concat(genre, ' ',count)" />
            <xsl:text>&#xA;</xsl:text>
        </xsl:for-each>
    </xsl:template>
    <xsl:template name="mostCommonrating" match="/report/reportStatistics/mostCommonRating">
        <xsl:for-each select="ratingCount">
            <xsl:value-of select="concat(rating, ' ',count)" />
            <xsl:text>&#xA;</xsl:text>
        </xsl:for-each>
    </xsl:template>
    <xsl:template name="mostCommonproducers" match="/report/reportStatistics/mostCommonProducers">
        <xsl:for-each select="producersCount">
            <xsl:value-of select="concat(producer, ' ',count)" />
            <xsl:text>&#xA;</xsl:text>
        </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>
