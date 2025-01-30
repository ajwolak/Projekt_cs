using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowRecepcjonisci : PobierzZBazyViewModel<Recepcjonisci>
    {
        public ShowRecepcjonisci():base("Lista recepcjonistów", "recepcjonisci") { }

        public override void Load()
        {
            List = new ObservableCollection<Recepcjonisci>(przychodniaEntities.Recepcjonisci.ToList());
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imię", "Nazwisko" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imię", "Nazwisko" };
        }

        public override void Sort()
        {
            if (SortField == "Imię")
                List = new ObservableCollection<Recepcjonisci>(List.OrderBy(x => x.Imie));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<Recepcjonisci>(List.OrderBy(x => x.Nazwisko));
        }

        public override void Find()
        {
            if (FindField == "Imię")
                List = new ObservableCollection<Recepcjonisci>(List.Where(item => item.Imie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<Recepcjonisci>(List.Where(item => item.Nazwisko.StartsWith(FindTextBox)));

        }
    }
}
