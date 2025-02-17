﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowyRecepcjonista : WstawDoBazyViewModel<Recepcjonisci>
    {
        public NowyRecepcjonista() : base("Dodajesz recepcojnistę")
        {
            Item = new Recepcjonisci();
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

        public override void Save()
        {
            przychodniaEntities.Recepcjonisci.Add(Item);
            przychodniaEntities.SaveChanges();
        }

    }
}
