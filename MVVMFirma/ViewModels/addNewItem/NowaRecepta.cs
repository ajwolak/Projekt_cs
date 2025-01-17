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
    public class NowaRecepta : WstawDoBazyViewModel<Recepty>
    {
        public NowaRecepta() 
        :base("Dodaj receptę")
        {
            Item = new Recepty();
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

        public DateTime? DataWystawienia
        {
            get { return Item.DataWystawienia; }
            set
            {
                Item.DataWystawienia = value;
                OnPropertyChanged(() => DataWystawienia);
            }
        }

        public IQueryable<KeyAndValue> ComboboxPacjent
        {
            get
            {
                return new PacjenciKlucze(przychodniaEntities).GetPacjenciKeyAndValue();
            }
        }

        public IQueryable<KeyAndValue> ComboboxLekarze
        {
            get
            {
                return new LekarzeBusiness(przychodniaEntities).GetLekKeyAndValueItems();
            }
        }

        public override void Save()
        {
            przychodniaEntities.Recepty.Add(Item);//dodanie do lokalnej kolekcji
            przychodniaEntities.SaveChanges();//zapisanie zmian do bazy 
        }
    }
}
