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
    public class NowyHarmonogramZabiegow : WstawDoBazyViewModel<HarmonogramZabiegow>
    {
        public NowyHarmonogramZabiegow()
        : base("Dodaj zabieg do harmonogramu")
        {
            Item = new HarmonogramZabiegow();
            Messenger.Default.Register<Zabiegi>(this, getWybranyZabieg);
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

        public int? LekarzID
        {
            get { return Item.LekarzID; }
            set
            {
                Item.LekarzID = value;
                OnPropertyChanged(() => LekarzID);
            }
        }

        public int? ZabiegID
        {
            get { return Item.ZabiegID; }
            set
            {
                Item.ZabiegID = value;
                OnPropertyChanged(() => ZabiegID);
            }
        }
        public String ZabiegDane
        {
            get; set;
        }

        public DateTime? DataZabiegu
        {
            get { return Item.DataZabiegu; }
            set
            {
                Item.DataZabiegu = value;
                OnPropertyChanged(() => DataZabiegu);
            }
        }

        public IQueryable<KeyAndValue> ComboboxPacjent
        {
            get
            {
                return new PacjenciKlucze(przychodniaEntities).GetPacjenciKeyAndValue();
            }
        }

        public IQueryable<KeyAndValue> ComboboxLekarz
        {
            get
            {
                return new LekarzeBusiness(przychodniaEntities).GetLekKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> ComboxZabiegi
        {
            get
            {
                return new ZabiegiKlucze(przychodniaEntities).GetZabiegiKeyAndValue();
            }
        }

        public override void Save()
        {
            przychodniaEntities.HarmonogramZabiegow.Add(Item);//dodanie do lokalnej kolekcji
            przychodniaEntities.SaveChanges();//zapisanie zmian do bazy 
        }

        private BaseCommand _showZabiegiCommand;
        public ICommand showZabiegiCommand //komenda do przycisku dodaj
        {
            get
            {
                if (_showZabiegiCommand == null)
                {
                    _showZabiegiCommand = new BaseCommand(() => pokazZabiegi());
                }
                return _showZabiegiCommand;
            }
        }

        private void pokazZabiegi()
        {
            Messenger.Default.Send<String>("PokazListeZZabiegami");
        }

        private void getWybranyZabieg(Zabiegi item)
        {
            ZabiegID = item.ZabiegID;
            ZabiegDane = item.Nazwa;
        }
    }
}
