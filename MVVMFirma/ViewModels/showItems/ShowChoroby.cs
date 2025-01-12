using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.showItems
{
    public  class ShowChoroby : PobierzZBazyViewModel<Choroby>
    {
        public override void Load()
        {
            List = new ObservableCollection<Choroby>(przychodniaEntities.Choroby.ToList());
        }
        public ShowChoroby():base("Lista chorób") {
        }
    }
}
