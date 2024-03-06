using Main.ViewModel;
using System.Windows;

namespace Main.View //same file path, xaml <Window x:Class="Main.View.MainWindow" same
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// View is ui
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
