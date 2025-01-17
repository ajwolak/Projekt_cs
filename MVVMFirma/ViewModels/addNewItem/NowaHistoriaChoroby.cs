using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.businessLogic;
using MVVMFirma.Models.businessLogic.dodawanieZKluczem;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowaHistoriaChoroby : WstawDoBazyViewModel<HistoriaChorob>
    {
        public NowaHistoriaChoroby()
            : base("Historia choroby")
        {
            Item = new HistoriaChorob();
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

        public int? ChorobaID
        {
            get { return Item.ChorobaID; }
            set
            {
                Item.ChorobaID = value;
                OnPropertyChanged(() => ChorobaID);
            }
        }

        public DateTime? DataDiagnozy
        {
            get { return Item.DataDiagnozy; }
            set
            {
                Item.DataDiagnozy = value;
                OnPropertyChanged(() => DataDiagnozy);
            }
        }

        public DateTime? DataWyleczenia
        {
            get { return Item.DataWyleczenia; }
            set
            {
                Item.DataWyleczenia = value;
                OnPropertyChanged(() => DataWyleczenia);
            }
        }

        public IQueryable<KeyAndValue> ComboboxPacjent
        {
            get
            {
                return new PacjenciKlucze(przychodniaEntities).GetPacjenciKeyAndValue();
            }
        }

        public IQueryable<KeyAndValue> ComboboxChoroby
        {
            get
            {
                return new ChorobyKlucze(przychodniaEntities).GetChorobyKeyAndValue();
            }
        }

        public override void Save()
        {
            przychodniaEntities.HistoriaChorob.Add(Item);//dodanie do lokalnej kolekcji
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
