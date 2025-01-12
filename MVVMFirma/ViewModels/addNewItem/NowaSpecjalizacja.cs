using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowaSpecjalizacja : WstawDoBazyViewModel<Specjalizacje>
    {
        public NowaSpecjalizacja() :base("Dodaj kolejną specjalizacje")
        {
            Item = new Specjalizacje();
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

        public override void Save()
        {
            przychodniaEntities.Specjalizacje.Add(Item);//dodanie do lokalnej kolekcji
            przychodniaEntities.SaveChanges();//zapisanie zmian do bazy 
        }
    }
}
