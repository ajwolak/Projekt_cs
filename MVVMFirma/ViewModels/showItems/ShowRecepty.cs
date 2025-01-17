using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowRecepty : PobierzZBazyViewModel<ReceptyForAllView>
    {
        public ShowRecepty() : base("Lista wystawionych recept", "recepty") { }

        public override void Load()
        {
            List = new ObservableCollection<ReceptyForAllView>(
                    from recepty in przychodniaEntities.Recepty
                    select new ReceptyForAllView
                    {
                        receptaId = recepty.ReceptaID,
                        pacjentData = recepty.Pacjenci.Imie +" "+ recepty.Pacjenci.Nazwisko,
                        lekarzData = recepty.Lekarze.Imie + " " + recepty.Lekarze.Nazwisko,
                        dataWystawienia = recepty.DataWystawienia
                    }
                );
        }
    }
}
