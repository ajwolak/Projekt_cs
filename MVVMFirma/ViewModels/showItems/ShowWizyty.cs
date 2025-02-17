﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.showItems;

namespace MVVMFirma.ViewModels.showItems
{
    public class ShowWizyty : PobierzZBazyViewModel<WizytyForAllView>
    {
        private bool closeTab;
        public ShowWizyty(bool closeTab = false) : base("Lista wizyt", "wizyty") { this.closeTab = closeTab; }

        public override void Load()
        {
            List = new ObservableCollection<WizytyForAllView>(
                from wizyta in przychodniaEntities.Wizyty
                select new WizytyForAllView
                {
                    wizytaId = wizyta.WizytaID,
                    pacjentData = wizyta.Pacjenci.Imie + " " + wizyta.Pacjenci.Nazwisko,
                    lekarzData = wizyta.Lekarze.Imie + " " + wizyta.Lekarze.Nazwisko,
                    dataWizyty = wizyta.DataWizyty,
                    notatka = wizyta.Notatka,
                    status = wizyta.Status,
                }
                );
        }

        private WizytyForAllView _wybranaWizyta;
        public WizytyForAllView wybranaWizyta
        {
            get { return _wybranaWizyta; }
            set
            {
                _wybranaWizyta = value;
                Messenger.Default.Send(_wybranaWizyta);
                if (closeTab)
                {
                    OnRequestClose();
                }
            }
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data", "Status" };
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Pacjent", "Lekarz" };
        }

        public override void Sort()
        {
            if (SortField == "Data")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.dataWizyty));
            if (SortField == "Status")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.status));
        }

        public override void Find()
        {
            if (FindField == "Pacjent")
                List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.pacjentData.StartsWith(FindTextBox)));
            if (FindField == "Lekarz")
                List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.lekarzData.StartsWith(FindTextBox)));
        }
    }
}
