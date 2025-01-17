using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowRecepcjonisci : PobierzZBazyViewModel<Recepcjonisci>
    {
        public ShowRecepcjonisci():base("Lista recepcjonistów", "recepcjonisci") { }

        public override void Load()
        {
            List = new ObservableCollection<Recepcjonisci>(przychodniaEntities.Recepcjonisci.ToList());
        }
    }
}
