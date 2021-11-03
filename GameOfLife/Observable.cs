using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameOfLife
{
    public abstract class Observable : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler? PropertyChanging;
        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool TrySetAndNotify<T>(ref T value, T newValue, [CallerMemberName] string? propertyName = null)
        {
            if(!Object.Equals(value, newValue))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
                value = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        protected void RaiseAllPropertiesChanged()
        {

        }
    }
}
