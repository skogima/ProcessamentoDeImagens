using System.Windows;

namespace ProjetoFinal
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
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
