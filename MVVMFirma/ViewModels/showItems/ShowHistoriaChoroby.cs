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
    }
}
