using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView.showItems
{
    public class WizytyForAllView
    {
        private DateTime? _dataWizyty;
        public int wizytaId { get; set; }
        public string pacjentData { get; set; }
        public string lekarzData { get; set; }

        public DateTime? dataWizyty
        {
            get { return _dataWizyty?.Date ?? DateTime.MinValue; }
            set { _dataWizyty = value; }
        }

        public string notatka { get; set; }
        public string status { get; set; }
    }

}
