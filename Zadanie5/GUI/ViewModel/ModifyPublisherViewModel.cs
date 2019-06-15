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
    public class ModifyPublisherViewModel : INotifyPropertyChanged
    {
        private string _publisherName;

        public ModifyPublisherViewModel()
        {
        }
        public ICommand ModifyPublisher { get { return new RelayCommand(ModifyPublisherFun, CanExecute); } }
        private void ModifyPublisherFun()
        {
            var dummy = ModifyPublisherWindow.AppWindow.Id.Split(' ');
            string id = dummy[1];
            var p = ModifyPublisherWindow.AppWindow.GamesXml.Publishers.Publishers.FirstOrDefault(x => x.PublisherId.Equals(id));
            if (!string.IsNullOrEmpty(_publisherName))
            {
                p.PublisherName = _publisherName;
            }
            ModifyPublisherWindow.AppWindow.ReloadMain.DynamicInvoke();
            MessageBox.Show("Publisher ID: " + p.PublisherId + " name: " + p.PublisherName + " was updated", "Added");
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
