using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMovieTheatre.ViewModel;

namespace WPFMovieTheatre.Command
{
    class AddBillCommand : ICommand
    {
        private ShowBillsViewModel showBillsViewModel;

        public AddBillCommand(ShowBillsViewModel showBillsViewModel)
        {
            this.showBillsViewModel = showBillsViewModel;
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
            return this.showBillsViewModel.CanAddBill;
        }

        public void Execute(object parameter)
        {
            this.showBillsViewModel.AddBill();
        }
        #endregion
    }
}
