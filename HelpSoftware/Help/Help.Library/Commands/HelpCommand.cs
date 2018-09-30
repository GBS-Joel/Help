using System;
using System.Windows.Input;

namespace Help.Library
{
  public class HelpCommand : ICommand
  {
    private readonly Action<object> _execute;
    private readonly Func<object, bool> _canExecute;

    public HelpCommand(Action<object> execute) : this(execute, null)
    {
    }

    public HelpCommand(Action<object> execute, Func<object, bool> canExecute)
    {
      _execute = execute ?? throw new ArgumentNullException(nameof(execute));
      _canExecute = canExecute ?? (x => true);
    }

    public bool CanExecute(object parameter)
    {
      return _canExecute(parameter);
    }

    public bool CanExecute()
    {
      return CanExecute(null);
    }

    public void Execute()
    {
      Execute(null);
    }

    public void Execute(object parameter)
    {
      _execute(parameter);
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

    public void Refresh()
    {
      CommandManager.InvalidateRequerySuggested();
    }
  }
}