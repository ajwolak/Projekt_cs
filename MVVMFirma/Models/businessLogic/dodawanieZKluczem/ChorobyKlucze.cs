using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;

namespace MVVMFirma.Models.businessLogic.dodawanieZKluczem
{
    public class ChorobyKlucze: DatabaseClass
    {
        public ChorobyKlucze(przychodniaEntities db)
         : base(db)
        {
        }

        public IQueryable<KeyAndValue> GetChorobyKeyAndValue()
        {
            return
                (
                    from item in db.Choroby
                    select new KeyAndValue
                    {
                        key = item.ChorobaID,
                        value = item.Nazwa,
                    }
                ).ToList().AsQueryable();
        }
    }
}
