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
    public class NowaHistoriaChoroby : WstawDoBazyViewModel<HistoriaChorob>
    {
        public NowaHistoriaChoroby()
            : base("Historia choroby")
        {
            Item = new HistoriaChorob();
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
    }
}
