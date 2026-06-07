using System.Windows;
using FinanceAnalysisSystem.ViewModels;

namespace FinanceAnalysisSystem.Views
{
    public partial class TransactionWindow : Window
    {
        public TransactionWindow()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is TransactionViewModel viewModel)
            {
                viewModel.Confirm();
                if (viewModel.IsConfirmed)
                    Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is TransactionViewModel viewModel)
                viewModel.Cancel();
            Close();
        }
    }
}