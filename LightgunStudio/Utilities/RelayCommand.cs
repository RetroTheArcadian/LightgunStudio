﻿using System.Windows.Input;

namespace LightgunStudio.Utilities
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _action;
        public RelayCommand(Action<object> action) { _action = action; _canExecute = null; }
        public RelayCommand(Action<object> action, Predicate<object> canExecute) { _action = action; _canExecute = canExecute; }
        public void Execute(object o) => _action(o);
        public bool CanExecute(object o) => _canExecute == null ? true : _canExecute(o);
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
