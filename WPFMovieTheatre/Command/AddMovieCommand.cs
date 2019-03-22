using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMovieTheatre.ViewModel;

namespace WPFMovieTheatre.Command
{
    class AddMovieCommand : ICommand
    {
        private MainWindowViewModel mainWindowViewModel;

        public AddMovieCommand(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return this.mainWindowViewModel.CanAddMovie;
        }

        public void Execute(object parameter)
        {
            this.mainWindowViewModel.AddMovie();
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
