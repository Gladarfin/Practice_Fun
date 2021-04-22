using PropertyChanged;
using System.ComponentModel;

namespace PredictorMVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
