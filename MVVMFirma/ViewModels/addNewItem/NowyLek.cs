using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowyLek : WstawDoBazyViewModel<Leki>
    {
        public NowyLek() :base("Dodaj nowy lek")
        {
            Item = new Leki();
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


        public override void Save()
        {
            przychodniaEntities.Leki.Add(Item);//dodanie do lokalnej kolekcji
            przychodniaEntities.SaveChanges();//zapisanie zmian do bazy 
        }
    }
}
