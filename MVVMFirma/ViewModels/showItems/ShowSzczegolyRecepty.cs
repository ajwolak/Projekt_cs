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
        public ShowSzczegolyRecepty():base("Szczegóły recept") { }

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
    }
}
