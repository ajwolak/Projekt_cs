using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowZabiegi : PobierzZBazyViewModel<Zabiegi>
    {
        private bool closeTab;
        public ShowZabiegi(bool closeTab = false) : base("Lista zabiegów", "zabiegi")
        {
            this.closeTab = closeTab;
        }

        public override void Load()
        {
            List = new ObservableCollection<Zabiegi>(przychodniaEntities.Zabiegi.ToList());
        }

        private Zabiegi _wybranyZabieg;

        public Zabiegi wybranyZabieg
        {
            get { return _wybranyZabieg; }
            set
            {
                _wybranyZabieg = value;
                Messenger.Default.Send(_wybranyZabieg);
                if (closeTab)
                {
                    OnRequestClose();
                }
            }
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Cena" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }

        public override void Sort()
        {
            List = new ObservableCollection<Zabiegi>(List.OrderBy(x => x.Cena));
        }

        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<Zabiegi>(List.Where(x => x.Nazwa.StartsWith(FindTextBox)));
            if(FindField == "Opis")
                List = new ObservableCollection<Zabiegi>(List.Where(x => x.Opis.StartsWith(FindTextBox)));
        }
    }
}
