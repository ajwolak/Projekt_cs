using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowHistoriaChoroby : PobierzZBazyViewModel<HistoriaChorobyForAllView>
    {
        public ShowHistoriaChoroby() : base("Historia wszystkich chorób", "historiaChorob")
        {
        }

        public override void Load()
        {
            List = new ObservableCollection<HistoriaChorobyForAllView>(
                from historia in przychodniaEntities.HistoriaChorob //dla każdej histori z bazy danych
                select new HistoriaChorobyForAllView //tworzymy nową historię choroby i uzupełniamy dane
                {
                    HistoriaID = historia.HistoriaID,
                    DataDiagnozy = historia.DataDiagnozy,
                    DataWyleczenia = historia.DataWyleczenia,
                    pacjentImie = historia.Pacjenci.Imie,
                    pacjentNazwisko = historia.Pacjenci.Nazwisko,
                    chorobaNazwa = historia.Choroby.Nazwa
                }
                );
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data diagnozy", "Data wyleczenia" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Pacjent", "Nazwa" };
        }

        public override void Sort()
        {
            if (SortField == "Data diagnozy")
                List = new ObservableCollection<HistoriaChorobyForAllView>(List.OrderBy(x => x.DataDiagnozy));
            if (SortField == "Data wyleczenia")
                List = new ObservableCollection<HistoriaChorobyForAllView>(List.OrderBy(x => x.DataWyleczenia));
        }

        public override void Find()
        {
            if (FindField == "Pacjent")
                List = new ObservableCollection<HistoriaChorobyForAllView>(List.Where(item => item.pacjentImie.StartsWith(FindTextBox) || item.pacjentNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Nazwa")
                List = new ObservableCollection<HistoriaChorobyForAllView>(List.Where(item => item.chorobaNazwa.StartsWith(FindTextBox)));
        }
    }
}
