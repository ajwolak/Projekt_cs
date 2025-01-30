using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowLekarze : PobierzZBazyViewModel<LekarzForAllView>
    {
        public ShowLekarze() : base("Lista lekarzy", "lekarze") { }

        public override void Load()
        {
            List = new ObservableCollection<LekarzForAllView>(
                from lekarze in przychodniaEntities.Lekarze
                select new LekarzForAllView
                {
                    lekarzId = lekarze.LekarzID,
                    lekarzImie = lekarze.Imie,
                    lekarzNazwisko = lekarze.Nazwisko,
                    nazwaSpecjalizacji = lekarze.Specjalizacje.Nazwa,
                    telefon = lekarze.Telefon,
                    email = lekarze.Email,
                }
                );
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
                List = new ObservableCollection<LekarzForAllView>(List.OrderBy(x => x.lekarzImie));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<LekarzForAllView>(List.OrderBy(x => x.lekarzNazwisko));
        }

        public override void Find()
        {
            if (FindField == "Imię")
                List = new ObservableCollection<LekarzForAllView>(List.Where(item => item.lekarzImie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<LekarzForAllView>(List.Where(item => item.lekarzNazwisko.StartsWith(FindTextBox)));

        }
    }
}
