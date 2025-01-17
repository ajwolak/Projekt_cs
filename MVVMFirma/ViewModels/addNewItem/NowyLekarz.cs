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
    public class NowyLekarz : WstawDoBazyViewModel<Lekarze>
    {
        public NowyLekarz()
        : base("Dodaj lekarza do bazy")
        {
            Item = new Lekarze();
        }

        public int? SpecjalizacjaID
        {
            get { return Item.SpecjalizacjaID; }
            set
            {
                Item.SpecjalizacjaID = value;
                OnPropertyChanged(() => SpecjalizacjaID);
            }
        }

        public string Imie
        {
            get { return Item.Imie; }
            set
            {
                Item.Imie = value;
                OnPropertyChanged(() => Imie);
            }
        }

        public string Nazwisko
        {
            get { return Item.Nazwisko; }
            set
            {
                Item.Nazwisko = value;
                OnPropertyChanged(() => Nazwisko);
            }
        }

        public string Telefon
        {
            get { return Item.Telefon; }
            set
            {
                Item.Telefon = value;
                OnPropertyChanged(() => Telefon);
            }
        }

        public string Email
        {
            get { return Item.Email; }
            set
            {
                Item.Email = value;
                OnPropertyChanged(() => Email);
            }
        }

        public IQueryable<KeyAndValue> ComboxSpecjalizacje
        {
            get
            {
                return new SpecjalizacjaKlucze(przychodniaEntities).GetSpecjalizacjaKeyAndValue();
            }
        }

        public override void Save()
        {
            przychodniaEntities.Lekarze.Add(Item);//dodanie do lokalnej kolekcji
            przychodniaEntities.SaveChanges();//zapisanie zmian do bazy 
        }
    }
}
