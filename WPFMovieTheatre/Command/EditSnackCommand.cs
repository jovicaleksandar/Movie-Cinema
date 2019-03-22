using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMovieTheatre.ViewModel;

namespace WPFMovieTheatre.Command
{
    class EditSnackCommand : ICommand
    {
        private MainWindowViewModel mainWindowViewModel;

        public EditSnackCommand(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        #region ICommandMethods
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }


        public bool CanExecute(object parameter)
        {
            return this.mainWindowViewModel.CanEditSnack;
        }

        public void Execute(object parameter)
        {
            this.mainWindowViewModel.EditSnack();
        }
        #endregion
    }
}
