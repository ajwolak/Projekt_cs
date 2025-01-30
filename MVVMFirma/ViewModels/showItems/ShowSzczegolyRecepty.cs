using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowSzczegolyRecepty : PobierzZBazyViewModel<SzczegolyReceptyForAllView>
    {
        public ShowSzczegolyRecepty() : base("Szczegóły recept", "szczegolyRecepty") { }

        public override void Load()
        {
            List = new ObservableCollection<SzczegolyReceptyForAllView>(
                from szczegoly in przychodniaEntities.SzczegolyRecept
                select new SzczegolyReceptyForAllView
                {
                    receptaId = szczegoly.Recepty.ReceptaID,
                    pacjentData = szczegoly.Recepty.Pacjenci.Imie + " " + szczegoly.Recepty.Pacjenci.Nazwisko,
                    lekarzData = szczegoly.Recepty.Lekarze.Imie + " " + szczegoly.Recepty.Lekarze.Nazwisko,
                    dataWystawienia = szczegoly.Recepty.DataWystawienia,
                    nazwaLeku = szczegoly.Leki.Nazwa,
                    ilosc = (int)szczegoly.Ilosc,
                }
                );
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data", "Ilość" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Pacjent", "Lekarz" };
        }

        public override void Sort()
        {
            if (SortField == "Data")
                List = new ObservableCollection<SzczegolyReceptyForAllView>(List.OrderBy(item => item.dataWystawienia));
            if (SortField == "Ilość")
                List = new ObservableCollection<SzczegolyReceptyForAllView>(List.OrderBy(item => item.ilosc));
        }

        public override void Find()
        {
            if (FindField == "Pacjent")
                List = new ObservableCollection<SzczegolyReceptyForAllView>(List.Where(item => item.pacjentData.StartsWith(FindTextBox)));
            if (FindField == "Lekarz")
                List = new ObservableCollection<SzczegolyReceptyForAllView>(List.Where(item => item.lekarzData.StartsWith(FindTextBox)));
        }
    }
}
