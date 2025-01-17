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
    public class NowaSzczegolaRecepty : WstawDoBazyViewModel<SzczegolyRecept>
    {
        public NowaSzczegolaRecepty()
        : base("Dodaj szczegół recepty")
        {
            Item = new SzczegolyRecept();
        }

        public int? ReceptaID
        {
            get { return Item.ReceptaID; }
            set
            {
                Item.ReceptaID = value;
                OnPropertyChanged(() => ReceptaID);
            }
        }

        public int? LekID
        {
            get { return Item.LekID; }
            set
            {
                Item.LekID = value;
                OnPropertyChanged(() => LekID);
            }
        }

        public int? Ilosc
        {
            get { return Item.Ilosc; }
            set
            {
                Item.Ilosc = value;
                OnPropertyChanged(() => Ilosc);
            }
        }

        public IQueryable<KeyAndValue> ComboxLeki
        {
            get
            {
                return new LekBusiness(przychodniaEntities).GetLekKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> ComboxRecepta
        {
            get
            {
                return new ReceptaKlucze(przychodniaEntities).GetReceptaKeyAndValue();
            }
        }

        public override void Save()
        {
            przychodniaEntities.SzczegolyRecept.Add(Item);//dodanie do lokalnej kolekcji
            przychodniaEntities.SaveChanges();//zapisanie zmian do bazy 
        }
    }
}
