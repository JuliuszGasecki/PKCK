using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.Model
{
    public static class DeleteItem
    {
        public static void RemoveItemById(GamesCatalogModel.GameCatalogRoot gameXml, string input)
        {
            if (input != null)
            {
                var dummy = input.Split(' ');
                string id = dummy[1]; 
                if (dummy[0].Contains("producer"))
                {
                    GamesCatalogModel.ProducerRoot.Producer p = gameXml.Producers.Producers.FirstOrDefault(x => x.ProducerId.Equals(id));
                    GamesCatalogModel.GameRoot.Game g = gameXml.Games.Games.FirstOrDefault(x => x.ProducerId.Equals(id));
                    if (g == null)
                    {
                        if (gameXml.Producers.Producers.Remove(p))
                        {
                            MessageBox.Show("Removed producer. ID: " + id, "Ok");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Game: " + g.Title + " is using this producer!", "Ok");
                    }
                }
                else if (dummy[0].Contains("engine"))
                {
                    GamesCatalogModel.GameEngineRoot.Engine e = gameXml.GameEngines.GameEngines.FirstOrDefault(x => x.EngineId == id);
                    GamesCatalogModel.GameRoot.Game g = gameXml.Games.Games.FirstOrDefault(x => x.EngineId.Equals(id));
                    if (g == null)
                    {
                        if (gameXml.GameEngines.GameEngines.Remove(e))
                        {
                            MessageBox.Show("Removed engine. ID: " + id, "Ok");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Game: " + g.Title + " is using this engine!", "Ok");
                    }
                }
                
                else if(dummy[0].Contains("publisher"))
                {
                    GamesCatalogModel.PublisherRoot.Publisher p = gameXml.Publishers.Publishers.FirstOrDefault(x => x.PublisherId == id);
                    GamesCatalogModel.GameRoot.Game g = gameXml.Games.Games.FirstOrDefault(x => x.PublisherId.Equals(id));
                    if (g == null)
                    {
                        if (gameXml.Publishers.Publishers.Remove(p))
                        {
                            MessageBox.Show("Removed publisher. ID: " + id, "Ok");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Game: " + g.Title + " is using this publisher!", "Ok");
                    }
                }
                else if(dummy[0].Contains("game"))
                {
                    id = "";
                    for (int i = 1; i < dummy.Length - 2; i++)
                    {
                        id += dummy[i] + " ";
                    }
                    id += dummy[dummy.Length - 2];
                    string date = dummy[dummy.Length-1];
                    GamesCatalogModel.GameRoot.Game g = gameXml.Games.Games.FirstOrDefault(x => x.Title == id && x.PremierDate.Substring(x.PremierDate.Length - 4) == date);
                    if (gameXml.Games.Games.Remove(g))
                    {
                        MessageBox.Show("Removed game. Title: " + id, "Ok");
                    }
                }
            }
        }
    }
}
