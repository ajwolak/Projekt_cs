using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using System.Windows.Input;
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
