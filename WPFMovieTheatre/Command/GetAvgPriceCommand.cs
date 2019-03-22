using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMovieTheatre.ViewModel;

namespace WPFMovieTheatre.Command
{
    class GetAvgPriceCommand : ICommand
    {
        private MainWindowViewModel mainWindowViewModel;

        public GetAvgPriceCommand(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return this.mainWindowViewModel.CanGetAvgPrice;
        }

        public void Execute(object parameter)
        {
            this.mainWindowViewModel.GetAvgPrice();
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