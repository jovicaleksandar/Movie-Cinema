using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMovieTheatre.ViewModel;

namespace WPFMovieTheatre.Command
{
    class EditAdminCommand : ICommand
    {
        private MainWindowViewModel mainWindowViewModel;

        public EditAdminCommand(MainWindowViewModel mainWindowViewModel)
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
            return this.mainWindowViewModel.CanEditAdmin;
        }

        public void Execute(object parameter)
        {
            this.mainWindowViewModel.EditAdmin();
        }
        #endregion
    }
}