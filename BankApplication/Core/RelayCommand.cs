using System;
using System.Windows.Input;

namespace BankApplication.Core;

public class RelayCommand : ICommand
{
    private Action<object> _execute;
    private Func<object, bool>? _canExecute;

#pragma warning disable CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.
    public event EventHandler CanExecuteChanged
#pragma warning restore CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.
    {
        add { CommandManager.RequerySuggested += value; }
        remove {  CommandManager.RequerySuggested -= value; }
    }

    public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute ?? null;
    }

#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
    public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).

#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
    public void Execute(object parameter) => _execute(parameter);
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
}