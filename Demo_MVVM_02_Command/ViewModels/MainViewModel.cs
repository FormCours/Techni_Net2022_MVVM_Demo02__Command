using Demo_MVVM_02_Command.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVVM_02_Command.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Field
        private int _Count;
        #endregion

        #region Props
        public int Count
        {
            get { return _Count; }
            set 
            { 
                _Count = value;
                RaisePropertyChanged();

                CommandPlus?.RaiseCanExecuteChanged();
                CommandMinus?.RaiseCanExecuteChanged();
            }
        }

        public IRelayCommand CommandPlus { get; set; }
        public IRelayCommand CommandMinus { get; set; }
        public IRelayCommand CommandReset { get; set; }
        #endregion

        #region Ctor
        public MainViewModel()
        {
            Count = 20;

            //CommandPlus = new RelayCommand(
            //    () => Count++,
            //    () => Count < 10
            //) ;
            CommandPlus = new RelayCommand(IncrCount, IncrCheck);
            CommandMinus = new RelayCommand(DecrCount, DecrCheck);
            CommandReset = new RelayCommand(ResetCount);
        }
        #endregion

        #region Méthode
        private void IncrCount()
        {
            Count++;
            //CommandPlus.RaiseCanExecuteChanged();
            //CommandMinus.RaiseCanExecuteChanged();
        }
        private bool IncrCheck()
        {
            return Count < 10;
        }

        private void DecrCount()
        {
            Count--;
            //CommandPlus.RaiseCanExecuteChanged();
            //CommandMinus.RaiseCanExecuteChanged();
        }
        private bool DecrCheck()
        {
            return Count > -10;
        }

        private void ResetCount()
        {
            Count = 0;
        }
        #endregion
    }
}
