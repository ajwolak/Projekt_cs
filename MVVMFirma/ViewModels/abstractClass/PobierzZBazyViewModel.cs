using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.Entities;
using System.Collections.ObjectModel;

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

        public PobierzZBazyViewModel(String name)
        {
            base.DisplayName = name;
            przychodniaEntities = new przychodniaEntities();
        }

        public abstract void Load();
    }
}
