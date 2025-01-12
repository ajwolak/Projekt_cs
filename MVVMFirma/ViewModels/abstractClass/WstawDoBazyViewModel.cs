using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public abstract class WstawDoBazyViewModel<T> : WorkspaceViewModel
    {
        protected przychodniaEntities przychodniaEntities;

        protected T Item;

        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;
            }
        }

        public WstawDoBazyViewModel(string name)
        {
            base.DisplayName = name;
            przychodniaEntities = new przychodniaEntities();
        }

        public void SaveAndClose()
        {
            Save();
            base.OnRequestClose();
        }

        public abstract void Save();
    }
}
