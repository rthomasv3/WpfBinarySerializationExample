using System;
using System.Windows.Input;

namespace CodeCompendium.WpfBinarySerializationExample
{
   /// <summary>
   /// Class used to create view model commands.
   /// </summary>
   public class RelayCommand : ICommand
   {
      #region Fields

      private readonly Predicate<object> _canExecute;
      private readonly Action<object> _execute;

      #endregion

      #region Constructors

      /// <summary>
      /// Creates a new instance of the <see cref="RelayCommand"/> class.
      /// </summary>
      public RelayCommand(Predicate<object> canExecute, Action<object> execute)
      {
         _canExecute = canExecute;
         _execute = execute;
      }

      /// <summary>
      /// Creates a new instance of the <see cref="RelayCommand"/> class.
      /// </summary>
      public RelayCommand(Action<object> execute)
      {
         _execute = execute;
         _canExecute = obj => true;
      }

      /// <summary>
      /// Creates a new instance of the <see cref="RelayCommand"/> class.
      /// </summary>
      public RelayCommand(Action execute)
      {
         _execute = obj => execute();
         _canExecute = obj => true;
      }

      /// <summary>
      /// Creates a new instance of the <see cref="RelayCommand"/> class.
      /// </summary>
      public RelayCommand(Func<bool> canExecute, Action execute)
      {
         _execute = obj => execute();
         _canExecute = obj => canExecute();
      }

      #endregion

      #region Events

      /// <summary>
      /// Event raised indicating the can execute predicate changed.
      /// </summary>
      public event EventHandler CanExecuteChanged
      {
         add { CommandManager.RequerySuggested += value; }
         remove { CommandManager.RequerySuggested -= value; }
      }

      #endregion

      #region Public Methods

      /// <summary>
      /// Evaluates the predicate given in the constructor (default true).
      /// </summary>
      public bool CanExecute(object parameter)
      {
         return _canExecute(parameter);
      }

      /// <summary>
      /// Executes the action given in the constructor.
      /// </summary>
      public void Execute(object parameter)
      {
         _execute(parameter);
      }

      #endregion
   }
}
