using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVVM_02_Command.Tools
{
    public class RelayCommand : IRelayCommand
    {
        #region Event
        public event EventHandler? CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        private readonly Action _Execute;
        private readonly Func<bool> _CanExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            if (execute is null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _Execute = execute;
            _CanExecute = canExecute;
        }

        public void Execute(object? parameter)
        {
            _Execute();
        }

        public bool CanExecute(object? parameter)
        {
            // return _CanExecute?.Invoke() ?? true;
            return _CanExecute is null ? true : _CanExecute();
        }
    }
}
