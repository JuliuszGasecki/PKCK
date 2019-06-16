using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Xml.Schema;
using GUI.Model;
using GUI.View;
using Logic;
using Microsoft.Win32;
using Utils;

namespace GUI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _xmlDisplayString;
        private string _myOwnXmlString;
        private string _xmlString;
        private string _xmlPath;
        private string _schemaPath;
        private string _selectedItemDummyC;
        private string _selectedItemDummyM;
        private string _selectedItemDummyD;
        private ObservableCollection<string> _catalogGameData;
        private ObservableCollection<string> _catalogGameDataToCreate;
        private GamesCatalogModel.GameCatalogRoot _gamesXml;

        public MainViewModel()
        {
        }

        public delegate void RefreshMain();

        public event RefreshMain ReloadListEvent;

        public void Reload()
        {
            InitializeFields();
        }

        #region ICommands

        public ICommand OpenFile
        {
            get { return new RelayCommand(OpenFileFun, CanExecute); }
        }

        public ICommand SaveToXml
        {
            get { return new RelayCommand(SaveToXmlFun, CanExecute); }
        }

        public ICommand DisplayXml
        {
            get { return new RelayCommand(DisplayXmlFun, CanExecute); }
        }

        public ICommand DisplayMyXml
        {
            get { return new RelayCommand(DisplayMyXmlFun, CanExecute); }
        }

        public ICommand SaveToHtml
        {
            get { return new RelayCommand(SaveToHtmlFun, CanExecute); }
        }

        #endregion

        #region privates

        private void SaveToHtmlFun()
        {
            if (_gamesXml != null)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "HTML file|*.html";
                if (saveFile.ShowDialog() == true)
                {
                    string directoryPath = saveFile.FileName;
                    if (directoryPath != "")
                    {
                        XmlUtils.TransformXmlToHtml(_xmlPath, directoryPath);
                        
                    }
                    else
                    {
                        MessageBox.Show("There is nothing to save.", "Error", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("There is no xml file which can be converted.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void OpenFileFun()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true;
            string xmlPath = "";
            string schemaPath = "";
            if (openFile.ShowDialog() == true)
            {
                foreach (string path in openFile.FileNames)
                {
                    if (path.Contains(".xml"))
                    {
                        xmlPath = path;
                        _xmlPath = path;
                    }

                    if (path.Contains(".xsd"))
                    {
                        schemaPath = path;
                        _schemaPath = path;
                    }
                }
            }

            if (xmlPath.Contains(".xml") && schemaPath.Contains(".xsd"))
            {
                if (XmlUtils.ValidateSchema(xmlPath, schemaPath))
                {
                    _gamesXml = XmlUtils.Deserialize<GamesCatalogModel.GameCatalogRoot>(xmlPath);
                    InitializeFields();
                }
            }

            else
            {
                if (xmlPath.Any() || schemaPath.Any())
                    MessageBox.Show("There is no XML file or XSD file!", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
            }
        }

        private void SaveToXmlFun()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XML file|*.xml";
            if (saveFile.ShowDialog() == true)
            {
                string directoryPath = saveFile.FileName;
                if (directoryPath != "" && _gamesXml != null)
                {
                    XmlUtils.Serialize<GamesCatalogModel.GameCatalogRoot>(_gamesXml, directoryPath);
                    if (!XmlUtils.ValidateSchema(directoryPath, _schemaPath))
                    {
                        File.Delete(directoryPath);
                    }
                }
                else
                {
                    MessageBox.Show("There is nothing to save.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DisplayXmlFun()
        {
            XmlString = _xmlString;
        }

        private void DisplayMyXmlFun()
        {
            XmlString = _myOwnXmlString;
        }

        private void InitializeFields()
        {
            _xmlString = XmlUtils.XmlToXmlString(_gamesXml);
            _myOwnXmlString = XmlToMyOwnXml(_gamesXml);
            DisplayXmlFun();
            CatalogGameDataToCreate = GetGameCatalogToCreate(_gamesXml);
            CatalogGameData = GetGameCatalog(_gamesXml);
            MainWindow.AppWindow.GamesXml = _gamesXml;
        }

        private ObservableCollection<string> GetGameCatalogToCreate(GamesCatalogModel.GameCatalogRoot gamesXml)
        {
            ObservableCollection<string> data = new ObservableCollection<string>
            {
                "Producer",
                "Game Engine",
                "Publisher",
                "Game"
            };
            return data;
        }

        private ObservableCollection<string> GetGameCatalog(GamesCatalogModel.GameCatalogRoot gamesXml)
        {
            ObservableCollection<string> data = new ObservableCollection<string>();
            foreach (var p in gamesXml.Producers.Producers)
            {
                data.Add("producer: " + p.ProducerId);
            }

            foreach (var g in gamesXml.GameEngines.GameEngines)
            {
                data.Add("engine: " + g.EngineId);
            }

            foreach (var p in gamesXml.Publishers.Publishers)
            {
                data.Add("publisher: " + p.PublisherId);
            }

            foreach (var g in gamesXml.Games.Games)
            {
                data.Add("game: " + g.Title + " " + g.PremierDate.Substring(g.PremierDate.Length - 4));
            }

            return data;
        }

        private string XmlToMyOwnXml(GamesCatalogModel.GameCatalogRoot gamesXml)
        {
            string output = "";
            output += "Games Catalog\n";
            output += "Header\n";
            output += "\tProject title: " + gamesXml.Header.TitleOfProject + "\n";
            output += "\tDescription: " + gamesXml.Header.Description + "\n";
            output += "\tAuthors:\n";
            foreach (var a in gamesXml.Header.Authors)
            {
                output += "\t\tStudent:" + "\n";
                foreach (var s in a.Students)
                {
                    output += "\t\t\t" + s.FirstName + " " + s.LastName + " " + s.Index + "\n";
                }
            }

            output += "\tModification Date: " + gamesXml.Header.ModificationDate + "\n";
            output += "\tUniversity: " + gamesXml.Header.University + "\n";

            output += "Producers\n";
            foreach (var p in gamesXml.Producers.Producers)
            {
                output += "\tID: " + p.ProducerId + "\n";
                output += "\tCompany Name: " + p.CompanyName + "\n";
                output += "\tFoundation Date: " + p.FoundationDate + "\n";
                output += "\tShare Price: " + p.SharePrice.Amount + " " + p.SharePrice.CurrencyId + "\n";
                output += "\tHeadquarter location: " + p.Headquarter + "\n";
                output += "\n";
            }

            output += "Game Engines\n";
            foreach (var ge in gamesXml.GameEngines.GameEngines)
            {
                output += "\tID: " + ge.EngineId + "\n";
                output += "\tName: " + ge.Name + "\n";
                output += "\tProgramming Language: " + ge.ProgrammingLanguage + "\n";
                output += "\tCompany: " + ge.Company + "\n";
            }

            output += "Publishers\n";
            foreach (var pu in gamesXml.Publishers.Publishers)
            {
                output += "\tID: " + pu.PublisherId + "\n";
                output += "\tName: " + pu.PublisherName + "\n";
            }

            output += "Ratings\n";
            foreach (var r in gamesXml.Ratings.Ratings)
            {
                output += "\tID: " + r.RatingId + "\n";
                output += "\tName: " + r.RatingName + "\n";
            }

            output += "Platforms\n";
            foreach (var p in gamesXml.Platforms.Platforms)
            {
                output += "\tID: " + p.PlatformId + "\n";
                output += "\tName: " + p.PlatformName + "\n";
            }

            output += "Genres\n";
            foreach (var g in gamesXml.Genres.Genres)
            {
                output += "\tID: " + g.GenreId + "\n";
                output += "\tName: " + g.GenreName + "\n";
            }

            output += "\n";
            output += "List of all games\n";
            foreach (var g in gamesXml.Games.Games)
            {
                output += "\tGame title: " + g.Title + "\n";
                output += "\t\tProducer: " + Getters.Producer(gamesXml.Producers.Producers, g.ProducerId) + "\n";
                output += "\t\tEngine: " + Getters.Engine(gamesXml.GameEngines.GameEngines, g.EngineId) + "\n";
                output += "\t\tPublisher: " + Getters.Publisher(gamesXml.Publishers.Publishers, g.PublisherId) + "\n";
                output += "\t\tRating: " + Getters.Rating(gamesXml.Ratings.Ratings, g.RatingId) + "\n";
                output += "\t\tPlatform: " + Getters.Platform(gamesXml.Platforms.Platforms, g.PlatformId) + "\n";
                output += "\t\tGenre: " + Getters.Genre(gamesXml.Genres.Genres, g.GenreId) + "\n";
                output += "\t\tDescription: " + g.Description + "\n";
                output += "\t\tPremier Price: " + g.PremierPrice.Amount + " " + g.PremierPrice.CurrencyId + "\n";
                output += "\t\tPremier Date: " + g.PremierDate + "\n";
                output += "\t\tScores: " + "\n";
                output += "\t\t\tMetaScore: " + g.MetariticRate.MetaScore + " User Score: " +
                          g.MetariticRate.UserScore + " Votes: " + g.MetariticRate.NumberOfVotes + "\n";
                output += "\n";
            }

            return output;
        }

        #endregion

        #region properties

        public string GetSelectedItemToCreate
        {
            get
            {
                if (_selectedItemDummyC != null)
                {
                    if (_selectedItemDummyC.Equals("Producer"))
                    {
                        CreateProducerWindow window = new CreateProducerWindow(_gamesXml);
                        ReloadListEvent += new RefreshMain(Reload);
                        window.ReloadMain = ReloadListEvent;
                        window.ShowDialog();
                    }

                    if (_selectedItemDummyC.Equals("Game Engine"))
                    {
                        CreateGameEngineWindow window = new CreateGameEngineWindow(_gamesXml);
                        ReloadListEvent += new RefreshMain(Reload);
                        window.ReloadMain = ReloadListEvent;
                        window.ShowDialog();
                    }

                    if (_selectedItemDummyC.Equals("Publisher"))
                    {
                        CreatePublisherWindow window = new CreatePublisherWindow(_gamesXml);
                        ReloadListEvent += new RefreshMain(Reload);
                        window.ReloadMain = ReloadListEvent;
                        window.ShowDialog();
                    }

                    if (_selectedItemDummyC.Equals("Game"))
                    {
                        CreateGameWindow window = new CreateGameWindow(_gamesXml);
                        ReloadListEvent += new RefreshMain(Reload);
                        window.ReloadMain = ReloadListEvent;
                        window.ShowDialog();
                    }
                }

                return _selectedItemDummyC;
            }
            set
            {
                _selectedItemDummyC = value;
                RaisePropertyChanged("GetSelectedItemToCreate");
            }
        }

        public string GetSelectedItemToDelete
        {
            get
            {
                if (_selectedItemDummyD != null)
                {
                    DeleteItem.RemoveItemById(_gamesXml, _selectedItemDummyD);
                    Reload();
                }

                return _selectedItemDummyD;
            }
            set
            {
                _selectedItemDummyD = value;
                RaisePropertyChanged("GetSelectedItemToDelete");
            }
        }

        public string GetSelectedItemToModify
        {
            get
            {
                if (_selectedItemDummyM != null)
                {
                    if (_selectedItemDummyM.Contains("producer"))
                    {
                        ModifyProducerWindow window = new ModifyProducerWindow(_selectedItemDummyM, _gamesXml);
                        ReloadListEvent += new RefreshMain(Reload);
                        window.ReloadMain = ReloadListEvent;
                        window.ShowDialog();
                    }

                    if (_selectedItemDummyM.Contains("publisher"))
                    {
                        ModifyPublisherWindow window = new ModifyPublisherWindow(_selectedItemDummyM, _gamesXml);
                        ReloadListEvent += new RefreshMain(Reload);
                        window.ReloadMain = ReloadListEvent;
                        window.ShowDialog();
                    }

                    if (_selectedItemDummyM.Contains("engine"))
                    {
                        ModifyGameEngineWindow window = new ModifyGameEngineWindow(_selectedItemDummyM, _gamesXml);
                        ReloadListEvent += new RefreshMain(Reload);
                        window.ReloadMain = ReloadListEvent;
                        window.ShowDialog();
                    }

                    if (_selectedItemDummyM.Contains("game"))
                    {
                        ModifyGameWindow window = new ModifyGameWindow(_selectedItemDummyM, _gamesXml);
                        ReloadListEvent += new RefreshMain(Reload);
                        window.ReloadMain = ReloadListEvent;
                        window.ShowDialog();
                    }
                }

                return _selectedItemDummyM;
            }
            set
            {
                _selectedItemDummyM = value;
                RaisePropertyChanged("GetSelectedItemToModify");
            }
        }

        public string XmlString
        {
            get => this._xmlDisplayString;
            set
            {
                _xmlDisplayString = value;
                RaisePropertyChanged("XmlString");
            }
        }

        public ObservableCollection<string> CatalogGameDataToCreate
        {
            get => this._catalogGameDataToCreate;
            set
            {
                _catalogGameDataToCreate = value;
                RaisePropertyChanged("CatalogGameDataToCreate");
            }
        }

        public ObservableCollection<string> CatalogGameData
        {
            get => this._catalogGameData;
            set
            {
                _catalogGameData = value;
                RaisePropertyChanged("CatalogGameData");
            }
        }

        #endregion


        #region others

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void RaisePropertyChanged(string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool CanExecute()
        {
            //Some logic
            return true;
        }

        private bool CanDeslectExecute()
        {
            return true;
        }
    }

    #endregion
}