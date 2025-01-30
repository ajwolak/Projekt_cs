using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowPlatnosci : PobierzZBazyViewModel<PlatnosciForAllView>
    {
        public ShowPlatnosci() : base("Lista płatności w przychodni", "platnosci") { }

        public override void Load()
        {
            List = new ObservableCollection<PlatnosciForAllView>(
                from platnosc in przychodniaEntities.Platnosci
                select new PlatnosciForAllView
                {
                    platnoscID = platnosc.PlatnoscID,
                    pacjentImie = platnosc.Wizyty.Pacjenci.Imie,
                    pacjentNazwisko = platnosc.Wizyty.Pacjenci.Nazwisko,
                    kwota = platnosc.Kwota,
                    dataPlatnosci = platnosc.DataPlatnosci,
                    metodaPlatnosci = platnosc.MetodaPlatnosci,
                }
                );
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Pacjent" };
        }

        public override void Sort()
        {
            List = new ObservableCollection<PlatnosciForAllView>(List.OrderBy(item => item.dataPlatnosci));
        }

        public override void Find()
        {
            if (FindField == "Pacjent")
                List = new ObservableCollection<PlatnosciForAllView>(List.Where(item => item.pacjentImie.StartsWith(FindTextBox) || item.pacjentNazwisko.StartsWith(FindTextBox)));
        }
    }
}
