using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
