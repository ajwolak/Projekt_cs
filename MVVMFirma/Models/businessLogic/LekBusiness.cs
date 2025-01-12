using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;

namespace MVVMFirma.Models.businessLogic
{
    public class LekBusiness:DatabaseClass
    {
        public LekBusiness(przychodniaEntities db)
            :base(db)
        {
        }

        //funkcja która będzie zwracała key i value leku (zwraca do comboboxa opcje w raporcie)

        public IQueryable<KeyAndValue> GetLekKeyAndValueItems()
        {
            return
                (
                    from Leki in db.Leki
                    select new KeyAndValue
                    {
                        key = Leki.LekID,
                        value = Leki.Nazwa,
                    }
                ).ToList().AsQueryable();
        }
    }
}
