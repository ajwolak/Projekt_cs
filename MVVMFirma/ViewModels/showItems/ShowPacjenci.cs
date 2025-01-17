using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.Entities;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowPacjenci : PobierzZBazyViewModel<Pacjenci>
    {
        private bool closeTab;
        public ShowPacjenci(bool closeTab = false) : base("Lista pacjentów", "pacjenci")
        {
            this.closeTab = closeTab;
        }

        private Pacjenci _wybranyPacjent;
        public Pacjenci wybranyPacjent
        {
            get { return _wybranyPacjent; }
            set
            {
                _wybranyPacjent = value;
                Messenger.Default.Send(_wybranyPacjent);
                if (closeTab)
                {
                    OnRequestClose();
                }
            }
        }

        public override void Load()
        {
            List = new ObservableCollection<Pacjenci>(przychodniaEntities.Pacjenci.ToList());
        }


    }
}
