using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.showItems
{
    public  class ShowChoroby : PobierzZBazyViewModel<Choroby>
    {
        public override void Load()
        {
            List = new ObservableCollection<Choroby>(przychodniaEntities.Choroby.ToList());
        }
        public ShowChoroby():base("Lista chorób", "choroby") {
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {"Nazwa" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }

        public override void Sort()
        {
            if(SortField == "Nazwa")
                List = new ObservableCollection<Choroby>(List.OrderBy(item => item.Nazwa));
            
        }

        public override void Find()
        {
            if(FindField == "Nazwa")
                List = new ObservableCollection<Choroby>(List.Where(item=> item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if(FindField == "Opis")
                List = new ObservableCollection<Choroby>(List.Where(item=> item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
    }
}
