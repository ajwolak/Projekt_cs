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
    public abstract class PobierzZBazyViewModel<T> : WorkspaceViewModel
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

        //sortowanie i filtrowanie

        //do sortowania

        //wynik wyboru z sortowania zostanie tu zapisany
        public string SortField { get; set; }

        public List<String> SortComboboxItems
        {
            get { return GetComboboxSortList(); }
        }

        public abstract List<String> GetComboboxSortList();

        private BaseCommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }

        public abstract void Sort();


        //do filtrowania

        public string FindField { get; set; }
        public string FindTextBox { get; set; }

        public List<String> FindComboboxItems
        {
            get { return GetComboboxFindList(); }
        }

        public abstract List<String> GetComboboxFindList();

        private BaseCommand _FindCommand;
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {
                    _FindCommand = new BaseCommand(() => Find());
                }
                return _FindCommand;
            }
        }

        public abstract void Find();
    }
}
