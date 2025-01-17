using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.Entities;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.ViewModels
{
    public abstract class PobierzZBazyViewModel<T>:WorkspaceViewModel
    {
        protected readonly przychodniaEntities przychodniaEntities;

        private ObservableCollection<T> _List;

        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }

        private BaseCommand _LoadCommand;
        public ICommand LoadComand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => Load());
                }
                return _LoadCommand;
            }
        }

        private BaseCommand _addCommand;
        public ICommand AddCommand //komenda do przycisku dodaj
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new BaseCommand(() => add());
                }
                return _addCommand;
            }
        }

        public PobierzZBazyViewModel(String name, String shortcut = "")
        {
            base.DisplayName = name;
            base.shortcut = shortcut;
            przychodniaEntities = new przychodniaEntities();
        }

        public abstract void Load();

        private void add()
        {
            //komenda z biblioteki mvvm light -dzięki niemu wysyłamy do innych obiektów komunikat DisplayNameAdd - gdzie DisplayName to nazwa okna
            Messenger.Default.Send(shortcut);
        }
    }
}
