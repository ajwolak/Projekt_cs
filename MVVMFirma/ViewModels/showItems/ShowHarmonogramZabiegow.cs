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
        public ShowHarmonogramZabiegow() : base("Lista zabiegów", "harmonogram") { }

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

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Pacjent", "Lekarz", "Nazwa" };
        }

        public override void Sort()
        {
            List = new ObservableCollection<HarmonogramZabieguForAllView>(List.OrderBy(item=>item.dataZabiegu));
        }

        public override void Find()
        {
            if (FindField == "Pacjent")
                List = new ObservableCollection<HarmonogramZabieguForAllView>(List.Where(item => item.pacjentImie.StartsWith(FindTextBox) || item.pacjentNazwisko.StartsWith(FindTextBox)));
            if(FindField == "Lekarz")
                List = new ObservableCollection<HarmonogramZabieguForAllView>(List.Where(item => item.lekarzImie.StartsWith(FindTextBox) || item.lekarzNazwisko.StartsWith(FindTextBox)));
            if(FindField == "Nazwa")
                List = new ObservableCollection<HarmonogramZabieguForAllView>(List.Where(item => item.nazwaZabiegu.StartsWith(FindTextBox)));
        }
    }
}
