using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView.showItems
{
    public class GrafikLekarzaForAllView
    {
        private DateTime? _dataRozpoczecia;
        private DateTime? _dataZakonczenia;
        public int GrafikID { get; set; }
        public DateTime? DataRozpoczecia
        {
            get { return _dataRozpoczecia?.Date ?? DateTime.MinValue; }
            set { _dataRozpoczecia = value; }
        }

        public DateTime? DataZakonczenia
        {
            get { return _dataZakonczenia?.Date ?? DateTime.MinValue; }
            set { _dataZakonczenia = value; }
        }
        public string lekarzImie { get; set; }
        public string lekarzNazwisko { get; set; }
    }
}
