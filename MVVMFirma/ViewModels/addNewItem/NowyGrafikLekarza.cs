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
    public class NowyGrafikLekarza : WstawDoBazyViewModel<GrafikLekarzy>
    {
        public NowyGrafikLekarza()
            :base("Dodaj grafik lekarza")
        {
            Item = new GrafikLekarzy();
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

        public DateTime? DataPoczatku
        {
            get { return Item.DataPoczatku; }
            set
            {
                Item.DataPoczatku = value;
                OnPropertyChanged(() => DataPoczatku);
            }
        }

        public DateTime? DataKonca
        {
            get { return Item.DataKonca; }
            set
            {
                Item.DataKonca = value;
                OnPropertyChanged(() => DataKonca);
            }
        }

        public IQueryable<KeyAndValue> ComboxLekarze
        {
            get
            {
                return new LekarzeBusiness(przychodniaEntities).GetLekKeyAndValueItems();
            }
        }

        public override void Save()
        {
            przychodniaEntities.GrafikLekarzy.Add(Item);//dodanie do lokalnej kolekcji
            przychodniaEntities.SaveChanges();//zapisanie zmian do bazy 
        }
    }
}
