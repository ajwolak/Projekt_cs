using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView.showItems
{
    public class LekarzForAllView
    {
        public int lekarzId {  get; set; }
        public string lekarzImie {  get; set; }
        public string lekarzNazwisko { get; set; }
        public string nazwaSpecjalizacji { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
    }
}
