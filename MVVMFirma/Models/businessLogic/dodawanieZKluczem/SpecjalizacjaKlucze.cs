using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;

namespace MVVMFirma.Models.businessLogic.dodawanieZKluczem
{
    public class SpecjalizacjaKlucze : DatabaseClass
    {
        public SpecjalizacjaKlucze(przychodniaEntities db)
       : base(db)
        {
        }

        public IQueryable<KeyAndValue> GetSpecjalizacjaKeyAndValue()
        {
            return
                (
                    from item in db.Specjalizacje
                    select new KeyAndValue
                    {
                        key = item.SpecjalizacjaID,
                        value = item.Nazwa,
                    }
                ).ToList().AsQueryable();
        }

    }
}
