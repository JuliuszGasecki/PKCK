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
    public class CreatePublisherViewModel : INotifyPropertyChanged
    {
        private string _publisherName;

        public CreatePublisherViewModel()
        {
        }
        public ICommand AddPublisher { get { return new RelayCommand(AddPublisherFun, CanExecute); } }
        private void AddPublisherFun()
        {
            var p = new GamesCatalogModel.PublisherRoot.Publisher
            {
                PublisherId = CreateId(),
                PublisherName = PublisherName
            };
            CreatePublisherWindow.AppWindow.GamesXml.Publishers.Publishers.Add(p);
            CreatePublisherWindow.AppWindow.ReloadMain.DynamicInvoke();
            MessageBox.Show("New publisher ID: " + p.PublisherId + " name: " + p.PublisherName + " was created", "Added");
        }

        private string CreateId()
        {
            string output = PublisherName.First().ToString().ToUpper() + PublisherName.Substring(1);
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

        public string PublisherName
        {
            get => this._publisherName;
            set
            {
                _publisherName = value;
                RaisePropertyChanged("PublisherName");
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
    }
    #endregion
}
