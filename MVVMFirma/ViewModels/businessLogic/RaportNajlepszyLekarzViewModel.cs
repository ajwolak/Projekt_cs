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
    public class RaportNajlepszyLekarzViewModel : WorkspaceViewModel
    {
        private przychodniaEntities db;
        public RaportNajlepszyLekarzViewModel()
        {
            base.DisplayName = "Raport sprzedanych leków";
            db = new przychodniaEntities();
            //domyślne zaznaczenia
            dataDo = DateTime.Now;
            dataOd = DateTime.Now;
            lekarz = "";
            wizyty = 0;
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

        private int _wizyty;
        public int wizyty
        {
            get { return _wizyty; }
            set
            {
                if (_wizyty != value)
                {
                    _wizyty = value;
                    OnPropertyChanged(() => wizyty);
                }
            }
        }

        private String _lekarz;
        public String lekarz
        {
            get { return _lekarz; }
            set
            {
                if (_lekarz != value)
                {
                    _lekarz = value;
                    OnPropertyChanged(() => lekarz);
                }
            }
        }


        //obsługa przycisku Sprawdź
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => sprawdzLekarza());
                }
                return _ObliczCommand;
            }
        }

        private void sprawdzLekarza()
        {
            NajlepszyLekarz item = new NajlepszyLekarz(db);
            lekarz = item.LekarzName(dataOd, dataDo);
            wizyty = item.LekarzWizyty(dataOd, dataDo);
        }
    }
}
