using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.Models.businessLogic
{
    public class LekarzeZysk:DatabaseClass
    {
        public LekarzeZysk(przychodniaEntities entities) : base(entities)
        {
        }

        //poniżej funkcja, obliczająca ile zarobił lekarz

        public decimal? ZyskLekarza(int idLekarza, DateTime dataOd, DateTime dataDo)
        {

            return
                (
                    from pozycja in db.Platnosci
                    where pozycja.Wizyty.LekarzID == idLekarza
                    && pozycja.Wizyty.DataWizyty >= dataOd
                    && pozycja.Wizyty.DataWizyty <= dataDo
                    select pozycja.Kwota
                ).Sum();
        }
    }
}
