using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowHarmonogramZabiegow : PobierzZBazyViewModel<HarmonogramZabieguForAllView>
    {
        public ShowHarmonogramZabiegow():base("Lista zabiegów") {}

        public override void Load()
        {
            List = new ObservableCollection<HarmonogramZabieguForAllView>(
                from harmonogram in przychodniaEntities.HarmonogramZabiegow
                select new HarmonogramZabieguForAllView
                {
                    HarmonogramId = harmonogram.HarmonogramID,
                    dataZabiegu = harmonogram.DataZabiegu,
                    lekarzImie = harmonogram.Lekarze.Imie,
                    lekarzNazwisko = harmonogram.Lekarze.Nazwisko,
                    pacjentImie = harmonogram.Pacjenci.Imie,
                    pacjentNazwisko = harmonogram.Pacjenci.Nazwisko,
                    nazwaZabiegu = harmonogram.Zabiegi.Nazwa,
                    opisZabiegu = harmonogram.Zabiegi.Opis,
                }
                );
        }
    }
}
