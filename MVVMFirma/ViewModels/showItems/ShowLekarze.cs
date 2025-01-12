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
        public ShowLekarze() : base("Lista lekarzy") { }

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
    }
}
