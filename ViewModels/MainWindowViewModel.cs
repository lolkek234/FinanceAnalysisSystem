using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FinanceAnalysisSystem.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<string> Transactions { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Profit => TotalIncome - TotalExpense;

        public MainWindowViewModel()
        {
            Transactions = new ObservableCollection<string>();
        }
    }
}
