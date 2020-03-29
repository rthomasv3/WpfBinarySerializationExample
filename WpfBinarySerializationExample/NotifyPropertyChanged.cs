using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CodeCompendium.WpfBinarySerializationExample
{
   /// <summary>
   /// Class used to provide set methods with property change events.
   /// </summary>
   public class NotifyPropertyChanged : INotifyPropertyChanged
   {
      #region Events

      /// <summary>
      /// The event to notify listeners when a property changed.
      /// </summary>
      public event PropertyChangedEventHandler PropertyChanged;

      #endregion

      #region Protected Methods

      protected void OnPropertyChanged([CallerMemberName] string callerName = "")
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
      }

      protected bool Set<T>(ref T obj, T value, [CallerMemberName] string callerName = "")
      {
         bool set = false;

         if ((obj != null && !obj.Equals(value)) || (obj == null && value != null))
         {
            obj = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
            set = true;
         }

         return set;
      }

      #endregion
   }
}
