using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;

namespace MVVMFirma.Models.businessLogic
{
    public class LekarzeBusiness: DatabaseClass
    {
        public LekarzeBusiness(przychodniaEntities db)
           : base(db)
        {
        }

        //funkcja która będzie zwracała key i value lekarza (zwraca do comboboxa opcje w raporcie)

        public IQueryable<KeyAndValue> GetLekKeyAndValueItems()
        {
            return
                (
                    from Lekarze in db.Lekarze
                    select new KeyAndValue
                    {
                        key = Lekarze.LekarzID,
                        value = Lekarze.Imie + " " + Lekarze.Nazwisko
                    }
                ).ToList().AsQueryable();
        }
    }
}
