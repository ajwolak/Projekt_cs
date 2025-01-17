using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;

namespace MVVMFirma.Models.businessLogic.dodawanieZKluczem
{
    internal class ReceptaKlucze: DatabaseClass
    {
        public ReceptaKlucze(przychodniaEntities db)
        : base(db)
        {
        }

        public IQueryable<KeyAndValue> GetReceptaKeyAndValue()
        {
            return
                (
                    from item in db.Recepty
                    select new KeyAndValue
                    {
                        key = item.ReceptaID,
                        value = item.Pacjenci.Imie + " " + item.Pacjenci.Nazwisko + " wystawił: " + item.Lekarze.Imie + " "+ item.Lekarze.Nazwisko + " dnia: " + item.DataWystawienia,
                    }
                ).ToList().AsQueryable();
        }
    }
}
