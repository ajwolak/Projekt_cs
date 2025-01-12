using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowZabiegi : PobierzZBazyViewModel<Zabiegi>
    {
        public ShowZabiegi():base("Lista zabiegów") { }

        public override void Load()
        {
            List = new ObservableCollection<Zabiegi>(przychodniaEntities.Zabiegi.ToList());
        }
    }
}
