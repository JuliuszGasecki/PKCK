using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GUI.Model
{
    public class GamesCatalogModel
    {
        [XmlRoot(ElementName = "header")]
        public class HeaderRoot
        {
            [XmlElement(ElementName = "polskieZnakiŹŻ")]
            public string polishLetters { get; set; }
            [XmlElement(ElementName = "titleOfProject")]
            public string TitleOfProject { get; set; }
            [XmlElement(ElementName = "description")]
            public string Description { get; set; }
            [XmlElement(ElementName = "authors")]
            public ObservableCollection<AuthorInfo> Authors { get; set; }
            [XmlRoot(ElementName = "authors")]
            public class AuthorInfo
            {
                [XmlElement(ElementName = "student")]
                public ObservableCollection<Student> Students { get; set; }
                [XmlRoot(ElementName = "student")]
                public class Student
                {
                    [XmlElement(ElementName = "firstName")]
                    public string FirstName { get; set; }
                    [XmlElement(ElementName = "lastName")]
                    public string LastName { get; set; }
                    [XmlElement(ElementName = "index")]
                    public string Index { get; set; }
                }
            }
            [XmlElement(ElementName = "modificationDate")]
            public string ModificationDate { get; set; }
            [XmlElement(ElementName = "university")]
            public string University { get; set; }

        }

        [XmlRoot(ElementName = "producers")]
        public class ProducerRoot
        {
            [XmlElement(ElementName = "producer")]
            public ObservableCollection<Producer> Producers { get; set; }

            [XmlRoot(ElementName = "producer")]
            public class Producer
            {
                [XmlAttribute(AttributeName = "producerID")]
                public string ProducerId { get; set; }
                [XmlElement(ElementName = "companyName")]
                public string CompanyName { get; set; }
                [XmlElement(ElementName = "foundationDate")]
                public int FoundationDate { get; set; }
                [XmlElement(ElementName = "sharePrice")]
                public SharePriceInfo SharePrice { get; set; }
                [XmlElement(ElementName = "headquarters")]
                public string Headquarter { get; set; }
                [XmlRoot(ElementName = "sharePrice")]
                public class SharePriceInfo
                {
                    [XmlAttribute(AttributeName = "currency")]
                    public string CurrencyId { get; set; }
                    [XmlText]
                    public string Amount { get; set; }
                }
            }
        }

        [XmlRoot(ElementName = "gameEngine")]
        public class GameEngineRoot
        {
            [XmlElement(ElementName = "engine")]
            public ObservableCollection<Engine> GameEngines { get; set; }
            [XmlRoot(ElementName = "engine")]
            public class Engine
            {
                [XmlAttribute(AttributeName = "engineID")]
                public string EngineId { get; set; }
                [XmlAttribute(AttributeName = "programmingLanguage")]
                public string ProgrammingLanguage { get; set; }
                [XmlElement(ElementName = "name")]
                public string Name { get; set; }
                [XmlElement(ElementName = "company")]
                public string Company { get; set; }
            }
        }

        [XmlRoot(ElementName = "publishers")]
        public class PublisherRoot
        {
            [XmlElement(ElementName = "publisher")]
            public ObservableCollection<Publisher> Publishers { get; set; }
            [XmlRoot(ElementName = "publisher")]
            public class Publisher
            {
                [XmlAttribute(AttributeName = "publisherID")]
                public string PublisherId { get; set; }
                [XmlElement(ElementName = "publisherName")]
                public string PublisherName { get; set; }
            }
        }

        [XmlRoot(ElementName = "Ratings")]
        public class RatingRoot
        {
            [XmlElement(ElementName = "Rating")]
            public ObservableCollection<Rating> Ratings { get; set; }
            [XmlRoot(ElementName = "Rating")]
            public class Rating
            {
                [XmlAttribute(AttributeName = "ratingID")]
                public string RatingId { get; set; }
                [XmlText]
                public string RatingName { get; set; }
            }
        }

        [XmlRoot(ElementName = "platforms")]
        public class PlatformRoot
        {
            [XmlElement(ElementName = "platform")]
            public ObservableCollection<Platform> Platforms { get; set; }
            [XmlRoot(ElementName = "platform")]
            public class Platform
            {
                [XmlAttribute(AttributeName = "platformID")]
                public string PlatformId { get; set; }
                [XmlText]
                public string PlatformName { get; set; }
            }
        }

        [XmlRoot(ElementName = "genres")]
        public class GenreRoot
        {
            [XmlElement(ElementName = "genre")]
            public ObservableCollection<Genre> Genres { get; set; }
            [XmlRoot(ElementName = "genre")]
            public class Genre
            {
                [XmlAttribute(AttributeName = "genreID")]
                public string GenreId { get; set; }
                [XmlText]
                public string GenreName { get; set; }
            }
        }


        [XmlRoot(ElementName = "Games")]
        public class GameRoot
        {
            [XmlElement(ElementName = "game")]
            public ObservableCollection<Game> Games { get; set; }

            [XmlRoot(ElementName = "game")]
            public class Game
            {
                [XmlAttribute(AttributeName = "producerID")]
                public string ProducerId { get; set; }
                [XmlAttribute(AttributeName = "engineID")]
                public string EngineId { get; set; }
                [XmlAttribute(AttributeName = "publisherID")]
                public string PublisherId { get; set; }
                [XmlAttribute(AttributeName = "ratingID")]
                public string RatingId { get; set; }
                [XmlAttribute(AttributeName = "platformID")]
                public string PlatformId { get; set; }
                [XmlAttribute(AttributeName = "genreID")]
                public string GenreId { get; set; }
                [XmlElement(ElementName = "title")]
                public string Title { get; set; }
                [XmlElement(ElementName = "description")]
                public string Description { get; set; }

                [XmlElement(ElementName = "premierPrice")]
                public PremierPriceInfo PremierPrice { get; set; }
                [XmlRoot(ElementName = "premierPrice")]
                public class PremierPriceInfo
                {
                    [XmlAttribute(AttributeName = "currency")]
                    public string CurrencyId { get; set; }
                    [XmlText]
                    public string Amount { get; set; }
                }
                [XmlElement(ElementName = "premierDate")]
                public string PremierDate { get; set; }
                [XmlElement(ElementName = "metariticRate")]
                public MetariticRateInfo MetariticRate { get; set; }
                [XmlRoot(ElementName = "metariticRate")]
                public class MetariticRateInfo
                {
                    [XmlElement(ElementName = "metascore")]
                    public string MetaScore { get; set; }
                    [XmlElement(ElementName = "userScore")]
                    public string UserScore { get; set; }
                    [XmlElement(ElementName = "numberOfVotes")]
                    public int NumberOfVotes { get; set; }
                }

            }
        }

       // [XmlRoot(ElementName  = "GamesCatalog", Namespace = "http://www.foo.com")]
        [XmlRoot(ElementName  = "GamesCatalog")]
        public class GameCatalogRoot
        {
            [XmlElement(ElementName = "header")]
            public HeaderRoot Header { get; set; }
            [XmlElement(ElementName = "producers")]
            public ProducerRoot Producers { get; set; }
            [XmlElement(ElementName = "gameEngines")]
            public GameEngineRoot GameEngines { get; set; }
            [XmlElement(ElementName = "publishers")]
            public PublisherRoot Publishers { get; set; }
            [XmlElement(ElementName = "Ratings")]
            public RatingRoot Ratings { get; set; }
            [XmlElement(ElementName = "platforms")]
            public PlatformRoot Platforms { get; set; }
            [XmlElement(ElementName = "genres")]
            public GenreRoot Genres { get; set; }
            [XmlElement(ElementName = "games")]
            public GameRoot Games { get; set; }
        }

    }
}
