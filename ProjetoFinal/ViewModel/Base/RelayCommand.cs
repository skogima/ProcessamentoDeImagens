using System;
using System.Windows.Input;

namespace ProjetoFinal
{
    public class RelayCommand : ICommand
    {
        private Action mAction;
        private Func<bool> mFunc;

        public event EventHandler CanExecuteChanged;

        #region Construtores
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public RelayCommand(Action action, Func<bool> func)
        {
            mAction = action;
            mFunc = func;
        }
        #endregion

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, null);
        }

        public bool CanExecute(object parameter)
        {
            return mFunc?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
