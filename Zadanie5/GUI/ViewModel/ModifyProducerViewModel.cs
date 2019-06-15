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
    public class ModifyProducerViewModel : INotifyPropertyChanged
    {
        private string _companyName;
        private string _foundationDate;
        private string _headquarter;
        private string _sharePrice;
        private ObservableCollection<string> _currencyList;
        private string _selectedItem;

        public ModifyProducerViewModel()
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

        public ICommand ModifyProducer
        {
            get { return new RelayCommand(ModifyProducerFun, CanExecute); }
        }

        private void ModifyProducerFun()
        {
            var dummy = ModifyProducerWindow.AppWindow.Id.Split(' ');
            string id = dummy[1];
            var p = ModifyProducerWindow.AppWindow.GamesXml.Producers.Producers.FirstOrDefault(x => x.ProducerId.Equals(id));
            if (!string.IsNullOrEmpty(_companyName))
            {
                p.CompanyName = _companyName;
            }
            if (!string.IsNullOrEmpty(_foundationDate))
            {
                p.FoundationDate = Int32.Parse(_foundationDate);
            }
            if (!string.IsNullOrEmpty(_headquarter))
            {
                p.Headquarter = _headquarter;
            }
            if (!string.IsNullOrEmpty(_sharePrice))
            {
                p.SharePrice.Amount = _sharePrice;
            }
            if (!string.IsNullOrEmpty(_selectedItem))
            {
                p.SharePrice.CurrencyId = _selectedItem;
            }
            ModifyProducerWindow.AppWindow.ReloadMain.DynamicInvoke();
            MessageBox.Show("Producer ID: " + p.ProducerId + " name: " + p.CompanyName + " was updated", "Added");
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