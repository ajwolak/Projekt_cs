using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowLeki : PobierzZBazyViewModel<Leki>
    {
        public ShowLeki():base("Lista leków") {}

        public override void Load()
        {
            List = new ObservableCollection<Leki>(przychodniaEntities.Leki.ToList());
        }
    }
}
