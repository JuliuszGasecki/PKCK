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
    public class CreateProducerViewModel : INotifyPropertyChanged
    {
        private string _companyName;
        private string _foundationDate;
        private string _headquarter;
        private string _sharePrice;
        private ObservableCollection<string> _currencyList;
        private string _selectedItem;

        public CreateProducerViewModel()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                _currencyList = new ObservableCollection<string>();
                _currencyList.Add("USD");
                _currencyList.Add("EURO");
                _currencyList.Add("PLN");
                CurrencyList = _currencyList;
            }
        }

        public ICommand AddProducer
        {
            get { return new RelayCommand(AddProducerFun, CanExecute); }
        }

        private void AddProducerFun()
        {
            var p = new GamesCatalogModel.ProducerRoot.Producer
            {
                ProducerId = CreateId(),
                CompanyName = CompanyName,
                FoundationDate = Int32.Parse(FoundationDate),
                Headquarter = Headquarter
            };
            var s = new GamesCatalogModel.ProducerRoot.Producer.SharePriceInfo
            {
                CurrencyId = GetSelectedItem, Amount = SharePrice
            };
            p.SharePrice = s;
            CreateProducerWindow.AppWindow.GamesXml.Producers.Producers.Add(p);
            CreateProducerWindow.AppWindow.ReloadMain.DynamicInvoke();
            MessageBox.Show("New producer ID: " + p.ProducerId + " name: " + p.CompanyName + " was created", "Added");
        }

        private string CreateId()
        {
            string output = CompanyName.First().ToString().ToUpper() + CompanyName.Substring(1);
            var letters = output.Split(' ');
            if (letters.Length == 1)
            {
                return output;
            }
            else
            {
                output = "";
                foreach (var l in letters)
                {
                    output += l[0];
                }

                return output;
            }
        }

        public string GetSelectedItem
        {
            get => this._selectedItem;
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("GetSelectedItem");
            }
        }

        public ObservableCollection<string> CurrencyList
        {
            get => this._currencyList;
            set
            {
                _currencyList = value;
                RaisePropertyChanged("CurrencyList");
            }
        }

        public string SharePrice
        {
            get => this._sharePrice;
            set
            {
                _sharePrice = value;
                RaisePropertyChanged("SharePrice");
            }
        }

        public string Headquarter
        {
            get => this._headquarter;
            set
            {
                _headquarter = value;
                RaisePropertyChanged("Headquarter");
            }
        }

        public string FoundationDate
        {
            get => this._foundationDate;
            set
            {
                _foundationDate = value;
                RaisePropertyChanged("FoundationDate");
            }
        }

        public string CompanyName
        {
            get => this._companyName;
            set
            {
                _companyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

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