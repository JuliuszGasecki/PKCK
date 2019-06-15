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
            GamesCatalogModel.ProducerRoot.Producer p = producers.FirstOrDefault(x => x.ProducerId == id);
            string output = p.CompanyName;
            return output; 
        }

        public static string Engine(ObservableCollection<GamesCatalogModel.GameEngineRoot.Engine> engines, string id)
        {
            GamesCatalogModel.GameEngineRoot.Engine e = engines.FirstOrDefault(x => x.EngineId == id);
            string output = e.Name;
            return output;
        }

        public static string Publisher(ObservableCollection<GamesCatalogModel.PublisherRoot.Publisher> publishers, string id)
        {
            GamesCatalogModel.PublisherRoot.Publisher p = publishers.FirstOrDefault(x => x.PublisherId == id);
            string output = p.PublisherName;
            return output;
        }

        public static string Rating(ObservableCollection<GamesCatalogModel.RatingRoot.Rating> ratings, string id)
        {
            GamesCatalogModel.RatingRoot.Rating r = ratings.FirstOrDefault(x => x.RatingId == id);
            string output = r.RatingName;
            return output;
        }

        public static string Platform(ObservableCollection<GamesCatalogModel.PlatformRoot.Platform> platforms, string id)
        {
            GamesCatalogModel.PlatformRoot.Platform p = platforms.FirstOrDefault(x => x.PlatformId == id);
            string output = p.PlatformName;
            return output;
        }

        public static string Genre(ObservableCollection<GamesCatalogModel.GenreRoot.Genre> genres, string id)
        {
            GamesCatalogModel.GenreRoot.Genre g = genres.FirstOrDefault(x => x.GenreId == id);
            string output = g.GenreName;
            return output;
        }
    }
}
