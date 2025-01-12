using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowyZabieg : WstawDoBazyViewModel<Zabiegi>

    {
        public NowyZabieg() : base("Dodaj nową usługę / zabieg")
        {
            Item = new Zabiegi();
        }

        public string Nazwa
        {
            get { return Item.Nazwa; }
            set
            {
                Item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }

        public string Opis
        {
            get { return Item.Opis; }
            set
            {
                Item.Opis = value;
                OnPropertyChanged(() => Opis);
            }
        }
        public decimal? Cena
        {
            get { return Item.Cena; }
            set
            {
                Item.Cena = value;
                OnPropertyChanged(() => Cena);
            }
        }
        public override void Save()
        {
            przychodniaEntities.Zabiegi.Add(Item);//dodanie do lokalnej kolekcji
            przychodniaEntities.SaveChanges();//zapisanie zmian do bazy 
        }
    }
}
