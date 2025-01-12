using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView.showItems
{
    //w tej klasie zastępujemy klucze obce na dane
    public class HistoriaChorobyForAllView
    {
        private DateTime? _dataDiagnozy;
        private DateTime? _dataWyleczenia;
        public int HistoriaID { get; set; }
        public DateTime? DataDiagnozy
        {
            get{return _dataDiagnozy?.Date ?? DateTime.MinValue;}
            set { _dataDiagnozy = value; }
        }

        public DateTime? DataWyleczenia
        {
            get { return _dataWyleczenia?.Date ?? DateTime.MinValue; }
            set { _dataWyleczenia = value; }
        }
        public string pacjentImie { get; set; }
        public string pacjentNazwisko { get; set; }
        public string chorobaNazwa { get; set; }
    }
}
