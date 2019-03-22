using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMovieTheatre.ViewModel;

namespace WPFMovieTheatre.Command
{
    class EditBillCommand : ICommand
    {
        private ShowBillsViewModel showBillsViewModel;

        public EditBillCommand(ShowBillsViewModel showBillsViewModel)
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
            return this.showBillsViewModel.CanEditBill;
        }

        public void Execute(object parameter)
        {
            this.showBillsViewModel.EditBill();
        }
        #endregion
    }
}
