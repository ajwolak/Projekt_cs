using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowaChoroba : WstawDoBazyViewModel<Choroby>
    {

        public NowaChoroba() : base("Dodaj nową chorobę")
        {
            Item = new Choroby();
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
            przychodniaEntities.Choroby.Add(Item);//dodanie do lokalnej kolekcji
            przychodniaEntities.SaveChanges();//zapisanie zmian do bazy 
        }


    }
}
