using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowyPokoj : WstawDoBazyViewModel<Pokoje>
    {
        public NowyPokoj() : base("Dodaj nowy pokój")
        {
            Item = new Pokoje();
        }

        public string NumerPokoju
        {
            get { return Item.NumerPokoju; }
            set
            {
                Item.NumerPokoju = value;
                OnPropertyChanged(() => NumerPokoju);
            }
        }
        public string Typ
        {
            get { return Item.Typ; }
            set
            {
                Item.Typ = value;
                OnPropertyChanged(() => Typ);
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
            przychodniaEntities.Pokoje.Add(Item);
            przychodniaEntities.SaveChanges();
        }

    }
}
