﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowSpecjalizacje : PobierzZBazyViewModel<Specjalizacje>
    {
        public ShowSpecjalizacje():base("Lista specjalizacji", "specjalizacje") { }

        public override void Load()
        {
            List = new ObservableCollection<Specjalizacje>(przychodniaEntities.Specjalizacje.ToList());
        }
    }
}
