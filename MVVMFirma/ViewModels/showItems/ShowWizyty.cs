using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowWizyty : PobierzZBazyViewModel<WizytyForAllView>
    {
        public ShowWizyty() : base("Lista wizyt", "wizyty") { }

        public override void Load()
        {
            List = new ObservableCollection<WizytyForAllView>(
                from wizyta in przychodniaEntities.Wizyty
                select new WizytyForAllView
                {
                    wizytaId = wizyta.WizytaID,
                    pacjentData = wizyta.Pacjenci.Imie + " "+ wizyta.Pacjenci.Nazwisko,
                    lekarzData = wizyta.Lekarze.Imie + " " + wizyta.Lekarze.Nazwisko,
                    dataWizyty = wizyta.DataWizyty,
                    notatka = wizyta.Notatka,
                    status = wizyta.Status,
                }
                );
        }
    }
}
