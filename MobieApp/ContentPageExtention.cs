using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MobieApp
{
    //public static class ContentPageExtention :INotifyPropertyChanged
    //{

    //    public static bool SetProperty<T>(ref T backingStore, T value,
    //       [CallerMemberName] string propertyName = "",
    //       Action onChanged = null)
    //    {
    //        if (EqualityComparer<T>.Default.Equals(backingStore, value))
    //            return false;

    //        backingStore = value;
    //        onChanged?.Invoke();
    //        OnPropertyChanged(propertyName);
    //        return true;
    //    }

    //    #region INotifyPropertyChanged
    //    public static event PropertyChangedEventHandler PropertyChanged;
    //    public static void OnPropertyChanged([CallerMemberName] string propertyName = "")
    //    {
    //        var changed = PropertyChanged;
    //        if (changed == null)
    //            return;

    //        changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //    #endregion

    //}
}
