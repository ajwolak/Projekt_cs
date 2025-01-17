using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;

namespace MVVMFirma.Models.businessLogic.dodawanieZKluczem
{
    internal class WizytyKlucze: DatabaseClass
    {
        public WizytyKlucze(przychodniaEntities db)
        : base(db)
        {
        }

        public IQueryable<KeyAndValue> GetWizytyKeyAndValue()
        {
            return
                (
                    from item in db.Wizyty
                    select new KeyAndValue
                    {
                        key = item.WizytaID,
                        value = item.Pacjenci.Imie + " " + item.Pacjenci.Nazwisko + " - " + item.Notatka,
                    }
                ).ToList().AsQueryable();
        }
    }

}
