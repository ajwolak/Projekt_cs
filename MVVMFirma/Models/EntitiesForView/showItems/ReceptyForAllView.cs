using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView.showItems
{
    public  class ReceptyForAllView
    {
        private DateTime? _dataWystawienia;
        public int receptaId { get; set; }
        public string pacjentData { get; set; }
        public string lekarzData { get; set; }

        public DateTime? dataWystawienia
        {
            get { return _dataWystawienia?.Date ?? DateTime.MinValue; }
            set { _dataWystawienia = value; }
        }

    }
}
