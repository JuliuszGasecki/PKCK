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
    public class ModifyGameEngineViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _company;
        private string _language;

        public ICommand ModifyGameEngine { get { return new RelayCommand(ModifyGameEngineFun, CanExecute); } }
        private void ModifyGameEngineFun()
        {
            var dummy = ModifyGameEngineWindow.AppWindow.Id.Split(' ');
            string id = dummy[1];
            var g = ModifyGameEngineWindow.AppWindow.GamesXml.GameEngines.GameEngines.FirstOrDefault(x => x.EngineId.Equals(id));
            if (!string.IsNullOrEmpty(_name))
            {
                g.Name = _name;
            }
            if (!string.IsNullOrEmpty(_company))
            {
                g.Company = _company;
            }
            if (!string.IsNullOrEmpty(_language))
            {
                g.ProgrammingLanguage = _language;
            }
            ModifyGameEngineWindow.AppWindow.ReloadMain.DynamicInvoke();
            MessageBox.Show("Game Engine ID: " + g.EngineId + " name: " + g.Name + " was updated", "Added");
        }

        public string Langauage
        {
            get => this._language;
            set
            {
                _language = value;
                RaisePropertyChanged("Langauage");
            }
        }
        public string Name
        {
            get => this._name;
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Company
        {
            get => this._company;
            set
            {
                _company = value;
                RaisePropertyChanged("Company");
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

