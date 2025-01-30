using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowSpecjalizacje : PobierzZBazyViewModel<Specjalizacje>
    {
        public ShowSpecjalizacje():base("Lista specjalizacji", "specjalizacje") { }

        public override void Load()
        {
            List = new ObservableCollection<Specjalizacje>(przychodniaEntities.Specjalizacje.ToList());
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {  "Nazwa" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Sort()
        {
            List = new ObservableCollection<Specjalizacje>(List.OrderBy(item => item.Nazwa));
        }

        public override void Find()
        {
            List = new ObservableCollection<Specjalizacje>(List.Where(item => item.Nazwa.StartsWith(FindTextBox)));
        }
    }
}
