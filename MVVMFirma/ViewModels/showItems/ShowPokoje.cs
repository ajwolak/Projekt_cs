using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowPokoje : PobierzZBazyViewModel<Pokoje>
    {
        public ShowPokoje():base("Lista sal", "pokoje") { }

        public override void Load()
        {
            List = new ObservableCollection<Pokoje>(przychodniaEntities.Pokoje.ToList());
        }
    }
}
