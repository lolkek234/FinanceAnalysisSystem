using System.Windows;
using FinanceAnalysisSystem.ViewModels;

namespace FinanceAnalysisSystem.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}