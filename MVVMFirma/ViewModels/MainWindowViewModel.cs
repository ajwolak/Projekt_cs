using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using MVVMFirma.ViewModels.showItems;
using MVVMFirma.ViewModels.businessLogic;

namespace MVVMFirma.ViewModels.addNewItem
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                  new CommandViewModel("Raport leków",                 new BaseCommand(() => this.CreateView( new RaportLekowViewModel() ))),

                  //***************************//
                  //***************************//

                  new CommandViewModel("Dodaj chorobę",                 new BaseCommand(() => this.CreateView( new NowaChoroba() ))),
                  new CommandViewModel("Dodaj historię choroby",        new BaseCommand(() => this.CreateView( new NowaHistoriaChoroby() ))),
                  new CommandViewModel("Dodaj płatność",                new BaseCommand(() => this.CreateView( new NowaPlatnosc() ))),
                  new CommandViewModel("Dodaj receptę",                 new BaseCommand(() => this.CreateView( new NowaRecepta() ))),
                  new CommandViewModel("Dodaj specjalizację",           new BaseCommand(() => this.CreateView( new NowaSpecjalizacja() ))),
                  new CommandViewModel("Dodaj szczegóły recepty",       new BaseCommand(() => this.CreateView( new NowaSzczegolaRecepty() ))),
                  new CommandViewModel("Dodaj wizytę",                  new BaseCommand(() => this.CreateView( new NowaWizyta() ))),
                  new CommandViewModel("Dodaj grafik lekarza",          new BaseCommand(() => this.CreateView( new NowyGrafikLekarza() ))),
                  new CommandViewModel("Dodaj harmonogram zabiegów",    new BaseCommand(() => this.CreateView( new NowyHarmonogramZabiegow() ))),
                  new CommandViewModel("Dodaj lek",                     new BaseCommand(() => this.CreateView( new NowyLek() ))),
                  new CommandViewModel("Dodaj lekarza",                 new BaseCommand(() => this.CreateView( new NowyLekarz() ))),
                  new CommandViewModel("Dodaj pacjenta",                new BaseCommand(() => this.CreateView( new NowyPacjent() ))),
                  new CommandViewModel("Dodaj pokój",                   new BaseCommand(() => this.CreateView( new NowyPokoj() ))),
                  new CommandViewModel("Dodaj recepcjoniste",           new BaseCommand(() => this.CreateView( new NowyRecepcjonista() ))),
                  new CommandViewModel("Dodaj zabieg",                  new BaseCommand(() => this.CreateView( new NowyZabieg() ))),
                  
                  //***************************//
                  //***************************//

                  new CommandViewModel("Lista chorób",                      new BaseCommand(()=>this.ShowWorkspace( new ShowChoroby() ))),
                  new CommandViewModel("Lista grafików lekarzy",            new BaseCommand(()=>this.ShowWorkspace( new ShowGrafikLekarza() ))),
                  new CommandViewModel("Lista z harmonogramami zabiegów",   new BaseCommand(()=>this.ShowWorkspace( new ShowHarmonogramZabiegow() ))),
                  new CommandViewModel("Lista z historiami chorób",         new BaseCommand(()=>this.ShowWorkspace( new ShowHistoriaChoroby() ))),
                  new CommandViewModel("Lista z lekarzami",                 new BaseCommand(()=>this.ShowWorkspace( new ShowLekarze() ))),
                  new CommandViewModel("Lista z lekami",                    new BaseCommand(()=>this.ShowWorkspace( new ShowLeki() ))),
                  new CommandViewModel("Lista z pacjentami",                new BaseCommand(()=>this.ShowWorkspace( new ShowPacjenci() ))),
                  new CommandViewModel("Lista z płatnościami",              new BaseCommand(()=>this.ShowWorkspace( new ShowPlatnosci() ))),
                  new CommandViewModel("Lista z pokojami",                  new BaseCommand(()=>this.ShowWorkspace( new ShowPokoje() ))),
                  new CommandViewModel("Lista z recepcjonistami",           new BaseCommand(()=>this.ShowWorkspace( new ShowRecepcjonisci() ))),
                  new CommandViewModel("Lista z receptami",                 new BaseCommand(()=>this.ShowWorkspace( new ShowRecepty() ))),
                  new CommandViewModel("Lista z specjalizacjami",           new BaseCommand(()=>this.ShowWorkspace( new ShowSpecjalizacje() ))),
                  new CommandViewModel("Lista z szczegółami recept",        new BaseCommand(()=>this.ShowWorkspace( new ShowSzczegolyRecepty() ))),
                  new CommandViewModel("Lista z wizytami",                  new BaseCommand(()=>this.ShowWorkspace( new ShowWizyty() ))),
                  new CommandViewModel("Lista z zabiegami",                 new BaseCommand(()=>this.ShowWorkspace( new ShowZabiegi() ))),
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void CreateView(WorkspaceViewModel nowy)
        {            
            this.Workspaces.Add(nowy);
            this.SetActiveWorkspace(nowy);
        }
        private void ShowWorkspace(WorkspaceViewModel workspace)
        {
            WorkspaceViewModel existingWorkspace = this.Workspaces.FirstOrDefault(vm => vm == workspace);
            if (existingWorkspace == null)
            {
                this.Workspaces.Add(workspace); 
            }
            this.SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
            {
                collectionView.MoveCurrentTo(workspace);
            }
        }

        #endregion
    }
}
