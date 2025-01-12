using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.Models.businessLogic
{
    public class NajlepszyLekarz: DatabaseClass
    {
        private int lekarzId = 0;
        public NajlepszyLekarz(przychodniaEntities entities) : base(entities)
        {
        }

        public string LekarzName(DateTime dataOd, DateTime dataDo)
        {
            var najlepszyLekarz =
                (from wizyta in db.Wizyty
                 where wizyta.DataWizyty >= dataOd && wizyta.DataWizyty <= dataDo
                 group wizyta by wizyta.LekarzID into grupy
                 orderby grupy.Count() descending
                 select new
                 {
                     LekarzID = grupy.Key,
                     LiczbaWizyt = grupy.Count()
                 }).FirstOrDefault();

            if (najlepszyLekarz == null)
                return "Brak lekarzy";

            var lekarz = db.Lekarze.FirstOrDefault(l => l.LekarzID == najlepszyLekarz.LekarzID);

            return lekarz != null ? $"{lekarz.Imie} {lekarz.Nazwisko}" : "Brak danych lekarza";
        }
        public int LekarzWizyty(DateTime dataOd, DateTime dataDo)
        {
            var najlepszyLekarz =
                (from wizyta in db.Wizyty
                 where wizyta.DataWizyty >= dataOd && wizyta.DataWizyty <= dataDo
                 group wizyta by wizyta.LekarzID into grupy
                 orderby grupy.Count() descending
                 select grupy.Count()).FirstOrDefault();

            return najlepszyLekarz; 
        }
    }
}
