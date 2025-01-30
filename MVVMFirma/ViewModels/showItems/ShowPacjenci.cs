﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.Entities;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowPacjenci : PobierzZBazyViewModel<Pacjenci>
    {
        private bool closeTab;
        public ShowPacjenci(bool closeTab = false) : base("Lista pacjentów", "pacjenci")
        {
            this.closeTab = closeTab;
        }

        private Pacjenci _wybranyPacjent;
        public Pacjenci wybranyPacjent
        {
            get { return _wybranyPacjent; }
            set
            {
                _wybranyPacjent = value;
                Messenger.Default.Send(_wybranyPacjent);
                if (closeTab)
                {
                    OnRequestClose();
                }
            }
        }

        public override void Load()
        {
            List = new ObservableCollection<Pacjenci>(przychodniaEntities.Pacjenci.ToList());
        }


        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imię", "Nazwisko" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imię", "Nazwisko" };
        }

        public override void Sort()
        {
            if (SortField == "Imię")
                List = new ObservableCollection<Pacjenci>(List.OrderBy(x => x.Imie));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<Pacjenci>(List.OrderBy(x => x.Nazwisko));
        }

        public override void Find()
        {
            if (FindField == "Imię")
                List = new ObservableCollection<Pacjenci>(List.Where(item => item.Imie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<Pacjenci>(List.Where(item => item.Nazwisko.StartsWith(FindTextBox)));

        }

    }
}
