﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMovieTheatre.ViewModel;

namespace WPFMovieTheatre.Command
{
    class EditWaiterCommand : ICommand
    {
        private MainWindowViewModel mainWindowViewModel;

        public EditWaiterCommand(MainWindowViewModel mainWindowViewModel)
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
            return this.mainWindowViewModel.CanEditWaiter;
        }

        public void Execute(object parameter)
        {
            this.mainWindowViewModel.EditWaiter();
        }
        #endregion
    }
}