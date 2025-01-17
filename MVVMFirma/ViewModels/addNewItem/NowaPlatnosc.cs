using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.businessLogic.dodawanieZKluczem;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowaPlatnosc : WstawDoBazyViewModel<Platnosci>
    {
        public NowaPlatnosc() 
        :base("Dodaj płatność")
        {
            Item = new Platnosci();
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
    }
}
