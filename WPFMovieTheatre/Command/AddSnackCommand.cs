using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMovieTheatre.ViewModel;

namespace WPFMovieTheatre.Command
{
    class AddSnackCommand : ICommand
    {
        private MainWindowViewModel mainWindowViewModel;

        public AddSnackCommand(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return this.mainWindowViewModel.CanAddSnack;
        }

        public void Execute(object parameter)
        {
            this.mainWindowViewModel.AddSnack();
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
        #endregion
    }
}
