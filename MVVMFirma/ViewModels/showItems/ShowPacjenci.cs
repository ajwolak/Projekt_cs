using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowPacjenci : PobierzZBazyViewModel<Pacjenci>
    {
        public ShowPacjenci():base("Lista pacjentów") {}

        public override void Load()
        {
            List = new ObservableCollection<Pacjenci>(przychodniaEntities.Pacjenci.ToList());
        }
    }
}
