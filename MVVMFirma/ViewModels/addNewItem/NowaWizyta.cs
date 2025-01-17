using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
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
            //messenger oczekujący na pacjenta zwidoku z listą pacjentów
            Messenger.Default.Register<Pacjenci>(this, getWybranyPacjent);
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

        public String PacjentDane
        {
            get; set;
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

        private BaseCommand _showPacjenciCommand;
        public ICommand ShowPacjenciCommand //komenda do przycisku dodaj
        {
            get
            {
                if (_showPacjenciCommand == null)
                {
                    _showPacjenciCommand = new BaseCommand(() => pokazPacjentow());
                }
                return _showPacjenciCommand;
            }
        }

        private void pokazPacjentow()
        {
            Messenger.Default.Send<String>("PokazListeZPacjentami");
        }

        private void getWybranyPacjent(Pacjenci pacjent)
        {
            PacjentID = pacjent.PacjentID;
            PacjentDane = pacjent.Imie + " " + pacjent.Nazwisko;
        }
    }
}
