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
        <xsl:value-of select="substring(concat('&#x20;',/report/reportInfo), 1, 50)" />
        <xsl:text>&#xA;</xsl:text>
    </xsl:template>

    <xsl:template name="game">
        <xsl:for-each select="report/game">
            <xsl:text>Title:</xsl:text>
            <xsl:value-of select="substring(concat('&#x20;',title), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Producer:</xsl:text>
            <xsl:value-of select="concat('&#x20;',producerName)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Publisher:</xsl:text>
            <xsl:value-of select="substring(concat('&#x20;',publisherName), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Engine:</xsl:text>
            <xsl:value-of select="substring(concat('&#x20;',engineName), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Rating:</xsl:text>
            <xsl:value-of select="substring(concat('&#x20;',ratingName), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Platform:</xsl:text>
            <xsl:value-of select="substring(concat('&#x20;',platformName), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Genre:</xsl:text>
            <xsl:value-of select="substring(concat('&#x20;',genreName), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Price:</xsl:text>
            <xsl:value-of select="substring(concat('&#x20;',price), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Date:</xsl:text>
            <xsl:value-of select="substring(concat('&#x20;',date), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>User Score:</xsl:text>
            <xsl:value-of select="substring(concat('&#x20;',userScore), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>Meta Score:</xsl:text>
            <xsl:value-of select="substring(concat('&#x20;',metaScore), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
            <xsl:text>&#xA;</xsl:text>
        </xsl:for-each>
    </xsl:template>
    <xsl:template name="GamesCatalog" match="/report/reportStatistics">
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>General:&#xA;</xsl:text>
        <xsl:text>Amount of games:</xsl:text>
        <xsl:value-of select="substring(concat('&#x20;',gamesCount), 1, 50)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Average Price:</xsl:text>
        <xsl:value-of select="substring(concat('&#x20;',averagePrice), 1, 50)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Average users rate:</xsl:text>
        <xsl:value-of select="substring(concat('&#x20;',averageUserRate), 1, 50)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Average critics rate:</xsl:text>
        <xsl:value-of select="substring(concat('&#x20;',averageCrirticRate), 1, 50)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Highest price:</xsl:text>
        <xsl:value-of select="substring(concat('&#x20;',highestPrice), 1, 50)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Lowest price:</xsl:text>
        <xsl:value-of select="substring(concat('&#x20;',lowestPrice), 1, 50)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Amount of publishers:</xsl:text>
        <xsl:value-of select="substring(concat('&#x20;',publishersCount), 1, 50)" />
        <xsl:text>&#xA;</xsl:text>
        <xsl:text>Amount of producers:</xsl:text>
        <xsl:value-of select="substring(concat('&#x20;',producersCount), 1, 50)" />
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
            <xsl:value-of select="substring(concat(genre, '&#x20;',count), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
        </xsl:for-each>
    </xsl:template>
    <xsl:template name="mostCommonrating" match="/report/reportStatistics/mostCommonRating">
        <xsl:for-each select="ratingCount">
            <xsl:value-of select="substring(concat(rating, '&#x20;',count), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
        </xsl:for-each>
    </xsl:template>
    <xsl:template name="mostCommonproducers" match="/report/reportStatistics/mostCommonProducers">
        <xsl:for-each select="producersCount">
            <xsl:value-of select="substring(concat(producers, '&#x20;',title), 1, 50)" />
            <xsl:text>&#xA;</xsl:text>
        </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>
