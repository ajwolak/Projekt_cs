using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowLeki : PobierzZBazyViewModel<Leki>
    {
        public ShowLeki():base("Lista leków", "leki") {}

        public override void Load()
        {
            List = new ObservableCollection<Leki>(przychodniaEntities.Leki.ToList());
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<Leki>(List.OrderBy(x => x.Nazwa));
        }

        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<Leki>(List.Where(x => x.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<Leki>(List.Where(x => x.Opis.StartsWith(FindTextBox)));
        }
    }
}
