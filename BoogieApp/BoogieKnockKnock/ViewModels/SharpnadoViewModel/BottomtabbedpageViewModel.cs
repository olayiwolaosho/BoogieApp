using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoogieApp.BoogieKnockKnock.ViewModels.SharpnadoViewModel
{
    class BottomtabbedpageViewModel : BaseViewModel
    {
        private int _selectedViewModelIndex = 0;

        public int SelectedViewModelIndex
        {
            get =>  _selectedViewModelIndex;
            
            set
            {
                _selectedViewModelIndex = value;
                RaisePropertyChanged(() => SelectedViewModelIndex);
            }
        }
    }
}
