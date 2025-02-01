using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.Entities;
using System.ComponentModel;

namespace MVVMFirma.ViewModels
{
    public abstract class WstawDoBazyViewModel<T> : WorkspaceViewModel, IDataErrorInfo
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

        public string Error => string.Empty;

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return ValidateProperty(propertyName);
            }
        }

        public WstawDoBazyViewModel(string name)
        {
            base.DisplayName = name;
            przychodniaEntities = new przychodniaEntities();
        }

        public virtual string ValidateProperty(string propertyName)
        {

            return string.Empty;

        }

        public void SaveAndClose()
        {
            Save();
            base.OnRequestClose();
        }


        public abstract void Save();

        public virtual bool IsValid()
        {
            return !typeof(T).GetProperties().Any(
                 item => ValidateProperty(item.Name) != string.Empty
                 );
        }
    }
}
