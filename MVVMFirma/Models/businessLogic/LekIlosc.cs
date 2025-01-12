using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.Models.businessLogic
{
    public class LekIlosc : DatabaseClass
    {
        public LekIlosc(przychodniaEntities entities) : base(entities)
        {
        }

        //poniżej funkcja, obliczająca ile jest sprzedanych leków

        public int? IloscLekow(int idLeku, DateTime dataOd, DateTime dataDo)
        {

            return
                (
                    from pozycja in db.SzczegolyRecept
                    where pozycja.LekID == idLeku
                    && pozycja.Recepty.DataWystawienia >= dataOd
                    && pozycja.Recepty.DataWystawienia <= dataDo
                    select pozycja.Ilosc
                ).Sum();
        }
    }
}
