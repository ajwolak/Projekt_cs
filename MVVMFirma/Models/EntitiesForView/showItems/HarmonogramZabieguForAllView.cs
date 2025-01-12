using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView.showItems
{
    public class HarmonogramZabieguForAllView
    {
        private DateTime? _dataZabiegu;
        public int HarmonogramId { get; set; }
        public DateTime? dataZabiegu
        {
            get { return _dataZabiegu?.Date ?? DateTime.MinValue; }
            set { _dataZabiegu = value; }
        }
        public string lekarzImie { get; set; }
        public string lekarzNazwisko { get; set; }
        public string pacjentNazwisko { get; set; }
        public string pacjentImie { get; set; }
        public string nazwaZabiegu { get; set; }
        public string opisZabiegu { get; set; }
    }
}
