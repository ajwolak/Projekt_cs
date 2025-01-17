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
    }
}
