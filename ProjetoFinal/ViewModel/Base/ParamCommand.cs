using System;
using System.Windows.Input;

namespace ProjetoFinal
{
    public class ParamCommand : ICommand
    {
        private Action<object> mAction;

        public ParamCommand(Action<object> action)
        {
            mAction = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction(parameter);
        }
    }
}
