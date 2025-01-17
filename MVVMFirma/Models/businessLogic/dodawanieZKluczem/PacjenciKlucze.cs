using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;

namespace MVVMFirma.Models.businessLogic.dodawanieZKluczem
{
    public class PacjenciKlucze: DatabaseClass
    {
        public PacjenciKlucze(przychodniaEntities db)
           : base(db)
        {
        }

        public IQueryable<KeyAndValue> GetPacjenciKeyAndValue()
        {
            return
                (
                    from Pacjenci in db.Pacjenci
                    select new KeyAndValue
                    {
                        key = Pacjenci.PacjentID,
                        value = Pacjenci.Imie + " " + Pacjenci.Nazwisko
                    }
                ).ToList().AsQueryable();
        }
    }
}
