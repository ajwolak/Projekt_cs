using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Helper;
using MVVMFirma.Models.businessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView.businessLogic;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.businessLogic
{
    public class RaportZyskZWizytModelView : WorkspaceViewModel
    {
        private przychodniaEntities db;
        public RaportZyskZWizytModelView()
        {
            base.DisplayName = "Raport zysku z wizyt lekarzy";
            db = new przychodniaEntities();
            //domyślne zaznaczenia
            dataDo = DateTime.Now;
            dataOd = DateTime.Now;
            zysk = 0;
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

        private int _idLekarza;
        public int idLekarza
        {
            get { return _idLekarza; }
            set
            {
                if (_idLekarza != value)
                {
                    _idLekarza = value;
                    OnPropertyChanged(() => idLekarza);
                }
            }
        }

        private decimal? _zysk;
        public decimal? zysk
        {
            get { return _zysk; }
            set
            {
                if (_zysk != value)
                {
                    _zysk = value;
                    OnPropertyChanged(() => zysk);
                }
            }
        }

        //poniższy kod uzupełnia wszysktie leki w combobox
        public IQueryable<KeyAndValue> ComboxLekarze
        {
            get
            {
                return new LekarzeBusiness(db).GetLekKeyAndValueItems();
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
                    _ObliczCommand = new BaseCommand(() => obliczZysk());
                }
                return _ObliczCommand;
            }
        }

        private void obliczZysk()
        {
            zysk = new LekarzeZysk(db).ZyskLekarza(idLekarza, dataOd, dataDo);
        }
    }

}
