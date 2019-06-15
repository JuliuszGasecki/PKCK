using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GUI.Model;
using GUI.View;

namespace GUI.ViewModel
{
    public class ModifyGameViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<string> _producerIds;
        private ObservableCollection<string> _engineIds;
        private ObservableCollection<string> _publisherIds;
        private ObservableCollection<string> _ratingIds;
        private ObservableCollection<string> _platformIds;
        private ObservableCollection<string> _genreIds;
        private ObservableCollection<string> _currency;

        private string _selectedProducerId;
        private string _selectedEngineId;
        private string _selectedPublisherId;
        private string _selectedRatingId;
        private string _selectedPlatformId;
        private string _selectedGenreId;
        private string _selectedCurrency;

        private string _title;
        private string _description;
        private string _premierPrice;
        private string _premierDate;
        private string _metaScore;
        private string _userScore;
        private string _numberOfVotes;


        public ModifyGameViewModel()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                _producerIds = new ObservableCollection<string>();
                _engineIds = new ObservableCollection<string>();
                _publisherIds = new ObservableCollection<string>();
                _ratingIds = new ObservableCollection<string>();
                _platformIds = new ObservableCollection<string>();
                _genreIds = new ObservableCollection<string>();
                _currency = new ObservableCollection<string>();

                var gamesXml = ModifyGameWindow.AppWindow.GamesXml;
                foreach (var p in gamesXml.Producers.Producers)
                {
                    _producerIds.Add(p.ProducerId);
                }
                ProducerIds = _producerIds;

                foreach (var e in gamesXml.GameEngines.GameEngines)
                {
                    _engineIds.Add(e.EngineId);
                }
                EngineIds = _engineIds;

                foreach (var p in gamesXml.Publishers.Publishers)
                {
                    _publisherIds.Add(p.PublisherId);
                }
                PublisherIds = _publisherIds;

                foreach (var r in gamesXml.Ratings.Ratings)
                {
                    _ratingIds.Add(r.RatingId);
                }
                RatingIds = _ratingIds;

                foreach (var p in gamesXml.Platforms.Platforms)
                {
                    _platformIds.Add(p.PlatformId);
                }
                PlatformIds = _platformIds;

                foreach (var g in gamesXml.Genres.Genres)
                {
                    _genreIds.Add(g.GenreId);
                }
                GenreIds = _genreIds;

                _currency.Add("USD");
                _currency.Add("EURO");
                _currency.Add("PLN");
                Currency = _currency;
            }
        }

        public ICommand ModifyGame
        {
            get { return new RelayCommand(ModifyGameFun, CanExecute); }
        }

        private void ModifyGameFun()
        {
            var dummy = ModifyGameWindow.AppWindow.Id.Split(' ');
            string id = "";
            for (int i = 1; i < dummy.Length - 2; i++)
            {
                id += dummy[i] + " ";
            }
            id += dummy[dummy.Length - 2];
            string date = dummy[dummy.Length - 1];
            var g = ModifyGameWindow.AppWindow.GamesXml.Games.Games.FirstOrDefault(x => x.Title == id && x.PremierDate.Substring(x.PremierDate.Length - 4) == date);

            if (!string.IsNullOrEmpty(_selectedProducerId))
            {
                g.ProducerId = _selectedProducerId;
            }
            if (!string.IsNullOrEmpty(_selectedEngineId))
            {
                g.EngineId = _selectedEngineId;
            }
            if (!string.IsNullOrEmpty(_selectedPublisherId))
            {
                g.PublisherId = _selectedPublisherId;
            }
            if (!string.IsNullOrEmpty(_selectedRatingId))
            {
                g.RatingId = _selectedRatingId;
            }
            if (!string.IsNullOrEmpty(_selectedPlatformId))
            {
                g.PlatformId = _selectedPlatformId;
            }
            if (!string.IsNullOrEmpty(_selectedGenreId))
            {
                g.GenreId = _selectedGenreId;
            }
            if (!string.IsNullOrEmpty(_title))
            {
                g.Title = _title;
            }
            if (!string.IsNullOrEmpty(_description))
            {
                g.Description = _description;
            }
            if (!string.IsNullOrEmpty(_premierDate))
            {
                g.PremierDate = _premierDate;
            }
            if (!string.IsNullOrEmpty(_selectedCurrency))
            {
                g.PremierPrice.CurrencyId = _selectedCurrency;
            }
            if (!string.IsNullOrEmpty(_premierPrice))
            {
                g.PremierPrice.Amount = _premierPrice;
            }
            if (!string.IsNullOrEmpty(_metaScore))
            {
                g.MetariticRate.MetaScore= _metaScore;
            }
            if (!string.IsNullOrEmpty(_userScore))
            {
                g.MetariticRate.UserScore = _userScore;
            }
            if (!string.IsNullOrEmpty(_numberOfVotes))
            {
                g.MetariticRate.NumberOfVotes = Int32.Parse(_numberOfVotes);
            }

            ModifyGameWindow.AppWindow.ReloadMain.DynamicInvoke();
            MessageBox.Show("Game: " + g.Title + " was updated", "Added");
        }

        #region Databinding
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }
        public string PremierPrice
        {
            get => _premierPrice;
            set
            {
                _premierPrice = value;
                RaisePropertyChanged("PremierPrice");
            }
        }
        public string PremierDate
        {
            get => _premierDate;
            set
            {
                _premierDate = value;
                RaisePropertyChanged("PremierDate");
            }
        }
        public string MetaScore
        {
            get => _metaScore;
            set
            {
                _metaScore = value;
                RaisePropertyChanged("MetaScore");
            }
        }
        public string UserScore
        {
            get => _userScore;
            set
            {
                _userScore = value;
                RaisePropertyChanged("UserScore");
            }
        }
        public string NumberOfVotes
        {
            get => _numberOfVotes;
            set
            {
                _numberOfVotes = value;
                RaisePropertyChanged("NumberOfVotes");
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }
        public string SelectedProducerId
        {
            get => _selectedProducerId;
            set
            {
                _selectedProducerId = value;
                RaisePropertyChanged("SelectedProducerId");
            }
        }
        public string SelectedEngineId
        {
            get => _selectedEngineId;
            set
            {
                _selectedEngineId = value;
                RaisePropertyChanged("SelectedEngineId");
            }
        }
        public string SelectedPublisherId
        {
            get => _selectedPublisherId;
            set
            {
                _selectedPublisherId = value;
                RaisePropertyChanged("SelectedPublisherId");
            }
        }
        public string SelectedRatingId
        {
            get => _selectedRatingId;
            set
            {
                _selectedRatingId = value;
                RaisePropertyChanged("SelectedRatingId");
            }
        }
        public string SelectedPlatformId
        {
            get => _selectedPlatformId;
            set
            {
                _selectedPlatformId = value;
                RaisePropertyChanged("SelectedPlatformId");
            }
        }
        public string SelectedGenreId
        {
            get => _selectedGenreId;
            set
            {
                _selectedGenreId = value;
                RaisePropertyChanged("SelectedGenreId");
            }
        }
        public string SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                RaisePropertyChanged("SelectedCurrency");
            }
        }
        public ObservableCollection<string> Currency
        {
            get => this._currency;
            set
            {
                _currency = value;
                RaisePropertyChanged("Currency");
            }
        }
        public ObservableCollection<string> ProducerIds
        {
            get => this._producerIds;
            set
            {
                _producerIds = value;
                RaisePropertyChanged("ProducerIds");
            }
        }
        public ObservableCollection<string> EngineIds
        {
            get => this._engineIds;
            set
            {
                _engineIds = value;
                RaisePropertyChanged("EngineIds");
            }
        }
        public ObservableCollection<string> PublisherIds
        {
            get => this._publisherIds;
            set
            {
                _publisherIds = value;
                RaisePropertyChanged("PublisherIds");
            }
        }
        public ObservableCollection<string> RatingIds
        {
            get => this._ratingIds;
            set
            {
                _ratingIds = value;
                RaisePropertyChanged("RatingIds");
            }
        }
        public ObservableCollection<string> PlatformIds
        {
            get => this._platformIds;
            set
            {
                _platformIds = value;
                RaisePropertyChanged("PlatformIds");
            }
        }
        public ObservableCollection<string> GenreIds
        {
            get => this._genreIds;
            set
            {
                _genreIds = value;
                RaisePropertyChanged("GenreIds");
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
        #endregion
    }
}
