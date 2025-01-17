using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.businessLogic.dodawanieZKluczem;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowaPlatnosc : WstawDoBazyViewModel<Platnosci>
    {
        public NowaPlatnosc() 
        :base("Dodaj płatność")
        {
            Item = new Platnosci();
            Messenger.Default.Register<WizytyForAllView>(this, getWybranyPacjent);
        }

        public int? WizytaID
        {
            get { return Item.WizytaID; }
            set
            {
                Item.WizytaID = value;
                OnPropertyChanged(() => WizytaID);
            }
        }

        public String WizytaDane { get; set; }

        public decimal? Kwota
        {
            get { return Item.Kwota; }
            set
            {
                Item.Kwota = value;
                OnPropertyChanged(() => Kwota);
            }
        }
        public DateTime? DataPlatnosci
        {
            get { return Item.DataPlatnosci; }
            set
            {
                Item.DataPlatnosci = value;
                OnPropertyChanged(() => DataPlatnosci);
            }
        }

        public String MetodaPlatnosci
        {
            get { return Item.MetodaPlatnosci; }
            set
            {
                Item.MetodaPlatnosci = value;
                OnPropertyChanged(() => MetodaPlatnosci);
            }
        }

        public IQueryable<KeyAndValue> ComboboxWizyty
        {
            get
            {
                return new WizytyKlucze(przychodniaEntities).GetWizytyKeyAndValue();
            }
        }

        public override void Save()
        {
            przychodniaEntities.Platnosci.Add(Item);//dodanie do lokalnej kolekcji
            przychodniaEntities.SaveChanges();//zapisanie zmian do bazy 
        }

        private BaseCommand _showWizytaDane;
        public ICommand ShowWizytaDane //komenda do przycisku dodaj
        {
            get
            {
                if (_showWizytaDane == null)
                {
                    _showWizytaDane = new BaseCommand(() => pokazWizyty());
                }
                return _showWizytaDane;
            }
        }

        private void pokazWizyty()
        {
            Messenger.Default.Send<String>("PokazListeZWizytami");
        }

        private void getWybranyPacjent(WizytyForAllView item)
        {
            WizytaID = item.wizytaId;
            WizytaDane = item.pacjentData + " - " + item.notatka;
        }
    }
}
