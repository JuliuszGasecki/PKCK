using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GUI.Model;
using Utils;

namespace GUI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _xmlString;
        private GamesCatalogModel.GameCatalogRoot GamesXml;
        public MainViewModel()
        {
            GamesXml = XmlUtils.Deserialize<GamesCatalogModel.GameCatalogRoot>(@"c:\Users\bsbar\OneDrive\Pulpit\Zadanie1.xml");
            _xmlString = XmlUtils.ToXml(GamesXml);
        }

        public ICommand OpenFile { get { return new RelayCommand(OpenFileFun, CanExecute); } }

        public void OpenFileFun()
        {

        }


        public string XmlString
        {
            get => this._xmlString;
            set
            {
                _xmlString = value;
                RaisePropertyChanged("XmlString");
            }
        }

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
}
