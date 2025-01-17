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
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class NowaSzczegolaRecepty : WstawDoBazyViewModel<SzczegolyRecept>
    {
        public NowaSzczegolaRecepty()
        : base("Dodaj szczegół recepty")
        {
            Item = new SzczegolyRecept();
            Messenger.Default.Register<ReceptyForAllView>(this, getWybranaRecepta);
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

        public String ReceptaDane
        {
            get; set;
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

        private BaseCommand _showReceptaCommand;
        public ICommand ShowReceptaCommand //komenda do przycisku dodaj
        {
            get
            {
                if (_showReceptaCommand == null)
                {
                    _showReceptaCommand = new BaseCommand(() => pokazRecepty());
                }
                return _showReceptaCommand;
            }
        }

        private void pokazRecepty()
        {
            Messenger.Default.Send<String>("PokazListeZReceptami");
        }

        private void getWybranaRecepta(ReceptyForAllView recepta)
        {
            ReceptaID = recepta.receptaId;
            ReceptaDane = recepta.pacjentData;
        }
    }
}
