using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMovieTheatre.ViewModel;

namespace WPFMovieTheatre.Command
{
    class GetBillsCommand : ICommand
    {
        private MainWindowViewModel mainWindowViewModel;

        public GetBillsCommand(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        
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
            return this.mainWindowViewModel.CanGetBills;
        }

        public void Execute(object parameter)
        {
            this.mainWindowViewModel.GetBills();
        }
    }
}
