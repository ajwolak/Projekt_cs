using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowRecepty : PobierzZBazyViewModel<ReceptyForAllView>
    {
        private bool closeTab;
        public ShowRecepty(bool closeTab = false) : base("Lista wystawionych recept", "recepty")
        {
            this.closeTab = closeTab;
        }

        private ReceptyForAllView _wybranaRecepta;
        public ReceptyForAllView wybranaRecepta
        {
            get { return _wybranaRecepta; }
            set
            {
                _wybranaRecepta = value;
                Messenger.Default.Send(_wybranaRecepta);
                if (closeTab)
                {
                    OnRequestClose();
                }
            }
        }

        public override void Load()
        {
            List = new ObservableCollection<ReceptyForAllView>(
                    from recepty in przychodniaEntities.Recepty
                    select new ReceptyForAllView
                    {
                        receptaId = recepty.ReceptaID,
                        pacjentData = recepty.Pacjenci.Imie + " " + recepty.Pacjenci.Nazwisko,
                        lekarzData = recepty.Lekarze.Imie + " " + recepty.Lekarze.Nazwisko,
                        dataWystawienia = recepty.DataWystawienia
                    }
                );
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Pacjent", "Lekarz" };
        }

        public override void Sort()
        {
            List = new ObservableCollection<ReceptyForAllView>(List.OrderBy(item => item.dataWystawienia));
        }

        public override void Find()
        {
            if (FindField == "Pacjent")
                List = new ObservableCollection<ReceptyForAllView>(List.Where(item => item.pacjentData.StartsWith(FindTextBox) ));
            if (FindField == "Lekarz")
                List = new ObservableCollection<ReceptyForAllView>(List.Where(item => item.lekarzData.StartsWith(FindTextBox)));
        }
    }
}
