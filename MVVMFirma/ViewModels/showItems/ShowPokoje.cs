using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowPokoje : PobierzZBazyViewModel<Pokoje>
    {
        public ShowPokoje() : base("Lista sal", "pokoje") { }

        public override void Load()
        {
            List = new ObservableCollection<Pokoje>(przychodniaEntities.Pokoje.ToList());
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Numer" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Typ", "Opis" };
        }

        public override void Sort()
        {
            List = new ObservableCollection<Pokoje>(List.OrderBy(item => item.NumerPokoju));
        }

        public override void Find()
        {
            if (FindField == "Typ")
                List = new ObservableCollection<Pokoje>(List.Where(item => item.Typ.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<Pokoje>(List.Where(item => item.Opis.StartsWith(FindTextBox)));
        }
    }
}
