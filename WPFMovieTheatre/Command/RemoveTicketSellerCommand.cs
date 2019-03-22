﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMovieTheatre.ViewModel;

namespace WPFMovieTheatre.Command
{
    class RemoveTicketSellerCommand : ICommand
    {
        private MainWindowViewModel mainWindowViewModel;

        public RemoveTicketSellerCommand(MainWindowViewModel mainWindowViewModel)
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
            return this.mainWindowViewModel.CanRemoveTicketSeller;
        }

        public void Execute(object parameter)
        {
            this.mainWindowViewModel.RemoveTicketSeller();
        }
        #endregion
    }
}