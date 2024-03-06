using Main.View;
using System.Windows;

namespace Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// start func // app.xaml startup
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void Application_Startup(object s, StartupEventArgs e)
        {
            MainWindow main = new();
            main.ShowDialog(); //open dependent window, block parent window control
            //main.Show(); //open independent window
        }
    }
}
