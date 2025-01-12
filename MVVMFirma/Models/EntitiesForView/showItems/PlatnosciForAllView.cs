using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView.showItems
{
    public class PlatnosciForAllView
    {
        private DateTime? _dataPlatnosci;
        private decimal? _kwota;
        public int platnoscID { get; set; }
        public string pacjentImie { get; set; }
        public string pacjentNazwisko { get; set; }
        public decimal? kwota { 
            get { return _kwota ?? 0; }
            set {  _kwota = value; }
        }
        public DateTime? dataPlatnosci
        {
            get { return _dataPlatnosci?.Date ?? DateTime.MinValue; }
            set { _dataPlatnosci = value; }
        }

        public string metodaPlatnosci { get; set; }
    }
}
