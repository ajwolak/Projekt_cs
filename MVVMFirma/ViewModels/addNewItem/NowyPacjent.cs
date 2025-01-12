using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowyPacjent : WstawDoBazyViewModel<Pacjenci>
    {
        public NowyPacjent() : base("Dodaj pacjenta")
        {
            Item = new Pacjenci();
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
        public DateTime? DataUrodzenia
        {
            get { return Item.DataUrodzenia; }
            set
            {
                Item.DataUrodzenia = value;
                OnPropertyChanged(() => DataUrodzenia);
            }
        }
        public string Pesel
        {
            get { return Item.Pesel; }
            set
            {
                Item.Pesel = value;
                OnPropertyChanged(() => Pesel);
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

        public override void Save()
        {
            przychodniaEntities.Pacjenci.Add(Item);
            przychodniaEntities.SaveChanges();
        }
    }
}
