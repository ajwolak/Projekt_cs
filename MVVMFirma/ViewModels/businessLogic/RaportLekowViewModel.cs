using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMFirma.Helper;
using MVVMFirma.Models.businessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;

namespace MVVMFirma.ViewModels.businessLogic
{
    public class RaportLekowViewModel : WorkspaceViewModel
    {
        private przychodniaEntities db;
        public RaportLekowViewModel()
        {
            base.DisplayName = "Raport sprzedanych leków";
            db = new przychodniaEntities();
            //domyślne zaznaczenia
            dataDo=DateTime.Now;
            dataOd=DateTime.Now;
            iloscLekow = 0;
        }


        private DateTime _dataOd;
        public DateTime dataOd
        {
            get { return _dataOd; }
            set
            {
                if (_dataOd != value)
                {
                    _dataOd = value;
                    OnPropertyChanged(() => dataOd);
                }
            }
        }
        private DateTime _dataDo;
        public DateTime dataDo
        {
            get { return _dataDo; }
            set
            {
                if (_dataDo != value)
                {
                    _dataDo = value;
                    OnPropertyChanged(() => dataDo);
                }
            }
        }

        private int _idTowaru;
        public int idTowaru
        {
            get { return _idTowaru; }
            set
            {
                if (_idTowaru != value)
                {
                    _idTowaru = value;
                    OnPropertyChanged(() => idTowaru);
                }
            }
        }

        private int? _iloscLekow;
        public int? iloscLekow
        {
            get { return _iloscLekow; }
            set
            {
                if (_iloscLekow != value)
                {
                    _iloscLekow = value;
                    OnPropertyChanged(() => iloscLekow);
                }
            }
        }

        //poniższy kod uzupełnia wszysktie leki w combobox
        public IQueryable<KeyAndValue> ComboboxLeki
        {
            get
            {
                return new LekBusiness(db).GetLekKeyAndValueItems();
            }
        }

        //obsługa przycisku oblicz
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => obliczIloscClick());
                }
                return _ObliczCommand;
            }
        }

        private void obliczIloscClick()
        {
            iloscLekow = new LekIlosc(db).IloscLekow(idTowaru, dataOd, dataDo);
        }
    }
}
