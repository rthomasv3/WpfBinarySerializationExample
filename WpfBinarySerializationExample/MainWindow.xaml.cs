using System.Windows;
using CodeCompendium.DependencyInjection;

namespace CodeCompendium.WpfBinarySerializationExample
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      /// <summary>
      /// Creates a new instance of the <see cref="MainWindow"/> class.
      /// </summary>
      public MainWindow()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Gets or sets the <see cref="MainWindow"/> view model (data context).
      /// </summary>
      [SimpleDependency]
      public MainWindowViewModel ViewModel
      {
         get { return DataContext as MainWindowViewModel; }
         set { DataContext = value; }
      }
   }
}
