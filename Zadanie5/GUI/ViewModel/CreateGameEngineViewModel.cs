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
    public class CreateGameEngineViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _company;
        private string _language;

        public ICommand AddGameEngine { get { return new RelayCommand(AddGameEngineFun, CanExecute); } }
        private void AddGameEngineFun()
        {
            var g = new GamesCatalogModel.GameEngineRoot.Engine
            {
                EngineId = CreateId(), Company = Company, Name = Name, ProgrammingLanguage = Langauage
            };
            CreateGameEngineWindow.AppWindow.GamesXml.GameEngines.GameEngines.Add(g);
            CreateGameEngineWindow.AppWindow.ReloadMain.DynamicInvoke();
            MessageBox.Show("New Game ID: " + g.EngineId + " name: " + g.Name + " was created", "Added");
        }

        private string CreateId()
        {
            string output = Name.First().ToString().ToUpper() + Name.Substring(1);
            output = output.Replace(" ", "");
            return output;
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

