using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.businessLogic;
using MVVMFirma.Models.businessLogic.dodawanieZKluczem;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowaWizyta : WstawDoBazyViewModel<Wizyty>
    {
        public NowaWizyta()
        : base("Dodaj nową wizytę")
        {
            Item = new Wizyty();
        }
        public int? PacjentID
        {
            get { return Item.PacjentID; }
            set
            {
                Item.PacjentID = value;
                OnPropertyChanged(() => PacjentID);
            }
        }

        public int? LekarzID
        {
            get { return Item.LekarzID; }
            set
            {
                Item.LekarzID = value;
                OnPropertyChanged(() => LekarzID);
            }
        }

        public DateTime? DataWizyty
        {
            get { return Item.DataWizyty; }
            set
            {
                Item.DataWizyty = value;
                OnPropertyChanged(() => DataWizyty);
            }
        }

        public String Notatka
        {
            get { return Item.Notatka; }
            set
            {
                Item.Notatka = value;
                OnPropertyChanged(() => Notatka);
            }
        }

        public String Status
        {
            get { return Item.Status; }
            set
            {
                Item.Status = value;
                OnPropertyChanged(() => Status);
            }
        }

        public IQueryable<KeyAndValue> ComboboxPacjent
        {
            get
            {
                return new PacjenciKlucze(przychodniaEntities).GetPacjenciKeyAndValue();
            }
        }

        public IQueryable<KeyAndValue> ComboxLekarz
        {
            get
            {
                return new LekarzeBusiness(przychodniaEntities).GetLekKeyAndValueItems();
            }
        }

        public override void Save()
        {
            przychodniaEntities.Wizyty.Add(Item);//dodanie do lokalnej kolekcji
            przychodniaEntities.SaveChanges();//zapisanie zmian do bazy 
        }
    }
}
