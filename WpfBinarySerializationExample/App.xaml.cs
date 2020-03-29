using System.Windows;
using CodeCompendium.BinarySerialization;
using CodeCompendium.DependencyInjection;

namespace CodeCompendium.WpfBinarySerializationExample
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      #region Fields

      private SimpleInjector _simpleInjector = new SimpleInjector();

      #endregion

      #region Constructor

      /// <summary>
      /// Creates a new instance of the <see cref="App"/> class.
      /// </summary>
      public App() : base()
      {
         _simpleInjector.RegisterSingleInstance<BinarySerializerOptions>();
         _simpleInjector.RegisterSingleInstance<BinarySerializer>();
         _simpleInjector.Resolve<MainWindow>().Show();
      }

      #endregion
   }
}
