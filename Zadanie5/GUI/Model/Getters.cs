using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Model;

namespace Logic
{
    public static class Getters
    {
        public static string Producer(ObservableCollection<GamesCatalogModel.ProducerRoot.Producer> producers, string id)
        {
            string output = "";
            GamesCatalogModel.ProducerRoot.Producer p = producers.FirstOrDefault(x => x.ProducerId == id);
            output = p.CompanyName;
            return output; 
        }

        public static string Engine(ObservableCollection<GamesCatalogModel.GameEngineRoot.Engine> engines, string id)
        {
            string output = "";
            GamesCatalogModel.GameEngineRoot.Engine e = engines.FirstOrDefault(x => x.EngineId == id);
             output = e.Name;
            return output;
        }

        public static string Publisher(ObservableCollection<GamesCatalogModel.PublisherRoot.Publisher> publishers, string id)
        {
            string output = "";
            GamesCatalogModel.PublisherRoot.Publisher p = publishers.FirstOrDefault(x => x.PublisherId == id);
            output = p.PublisherName;
            return output;
        }

        public static string Rating(ObservableCollection<GamesCatalogModel.RatingRoot.Rating> ratings, string id)
        {
            string output = "";
            GamesCatalogModel.RatingRoot.Rating r = ratings.FirstOrDefault(x => x.RatingId == id);
            output = r.RatingName;
            return output;
        }

        public static string Platform(ObservableCollection<GamesCatalogModel.PlatformRoot.Platform> platforms, string id)
        {
            string output = "";
            GamesCatalogModel.PlatformRoot.Platform p = platforms.FirstOrDefault(x => x.PlatformId == id);
            output = p.PlatformName;
            return output;
        }

        public static string Genre(ObservableCollection<GamesCatalogModel.GenreRoot.Genre> genres, string id)
        {
            string output = "";
            GamesCatalogModel.GenreRoot.Genre g = genres.FirstOrDefault(x => x.GenreId == id);
            output = g.GenreName;
            return output;
        }
    }
}
