using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;

namespace MVVMFirma.Models.businessLogic.dodawanieZKluczem
{
    public class ZabiegiKlucze: DatabaseClass
    {
        public ZabiegiKlucze(przychodniaEntities db)
        : base(db)
        {
        }

        public IQueryable<KeyAndValue> GetZabiegiKeyAndValue()
        {
            return
                (
                    from item in db.Zabiegi
                    select new KeyAndValue
                    {
                        key = item.ZabiegID,
                        value = item.Nazwa,
                    }
                ).ToList().AsQueryable();
        }
    }
}
