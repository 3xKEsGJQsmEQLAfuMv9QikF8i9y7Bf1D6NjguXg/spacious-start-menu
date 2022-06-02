using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SpaciousStartMenu.DataTypes
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (field is null &&
                value is null)
            {
                return;
            }
            if (field is null ||
                !field.Equals(value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
            }
        }
    }
}
