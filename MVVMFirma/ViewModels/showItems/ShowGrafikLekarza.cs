using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowGrafikLekarza : PobierzZBazyViewModel<GrafikLekarzaForAllView>
    {
        public ShowGrafikLekarza() : base("Grafiki lekarzy", "grafikLekarza") { }

        public override void Load()
        {
            List = new ObservableCollection<GrafikLekarzaForAllView>(
                from grafik in przychodniaEntities.GrafikLekarzy
                select new GrafikLekarzaForAllView
                {
                    GrafikID = grafik.GrafikID,
                    DataRozpoczecia = grafik.DataPoczatku,
                    DataZakonczenia = grafik.DataKonca,
                    lekarzImie = grafik.Lekarze.Imie,
                    lekarzNazwisko = grafik.Lekarze.Nazwisko,
                }
                );
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data początku", "Data końca" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Lekarz" };
        }

        public override void Sort()
        {
            if (SortField == "Data początku")
                List = new ObservableCollection<GrafikLekarzaForAllView>(List.OrderBy(item => item.DataRozpoczecia));
            if (SortField == "Data końca")
                List = new ObservableCollection<GrafikLekarzaForAllView>(List.OrderBy(item => item.DataZakonczenia));
        }

        public override void Find()
        {
            if (FindField == "Lekarz")
                List = new ObservableCollection<GrafikLekarzaForAllView>(List.Where(item => item.lekarzImie.StartsWith(FindTextBox) || item.lekarzNazwisko.StartsWith(FindTextBox)));
        }
    }
}
