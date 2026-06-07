using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using FinanceAnalysisSystem.Models;
using FinanceAnalysisSystem.Services;
using FinanceAnalysisSystem.Utils;
using FinanceAnalysisSystem.Views;

namespace FinanceAnalysisSystem.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly AnalysisService _analysisService;
        private readonly DataStorageService _storageService;
        private ObservableCollection<Transaction> _transactions;
        private decimal _totalIncome;
        private decimal _totalExpenses;
        private decimal _netProfit;

        public ObservableCollection<Transaction> Transactions
        {
            get => _transactions;
            set
            {
                if (_transactions != value)
                {
                    _transactions = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal TotalIncome
        {
            get => _totalIncome;
            set
            {
                if (_totalIncome != value)
                {
                    _totalIncome = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal TotalExpenses
        {
            get => _totalExpenses;
            set
            {
                if (_totalExpenses != value)
                {
                    _totalExpenses = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal NetProfit
        {
            get => _netProfit;
            set
            {
                if (_netProfit != value)
                {
                    _netProfit = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddTransactionCommand { get; }
        public ICommand DeleteTransactionCommand { get; }
        public ICommand ViewReportCommand { get; }
        public ICommand SaveCommand { get; }

        public MainWindowViewModel()
        {
            _analysisService = new AnalysisService();
            _storageService = new DataStorageService();
            Transactions = new ObservableCollection<Transaction>();

            AddTransactionCommand = new RelayCommand(_ => AddTransaction());
            DeleteTransactionCommand = new RelayCommand(param => DeleteTransaction(param));
            ViewReportCommand = new RelayCommand(_ => ViewReport());
            SaveCommand = new RelayCommand(_ => SaveData());

            LoadData();
        }

        private void AddTransaction()
        {
            var viewModel = new TransactionViewModel();
            var window = new TransactionWindow { DataContext = viewModel };
            window.ShowDialog();

            if (viewModel.IsConfirmed)
            {
                var transaction = new Transaction
                {
                    Id = Transactions.Count + 1,
                    Description = viewModel.Description,
                    Amount = viewModel.Amount,
                    Type = viewModel.Type,
                    Category = viewModel.Category,
                    Date = viewModel.Date
                };

                Transactions.Add(transaction);
                UpdateTotals();
                SaveData();
            }
        }

        private void DeleteTransaction(object param)
        {
            if (param is Transaction transaction)
            {
                Transactions.Remove(transaction);
                UpdateTotals();
                SaveData();
            }
        }

        private void ViewReport()
        {
            var report = _analysisService.GenerateReport(
                new List<Transaction>(Transactions),
                DateTime.Now.AddMonths(-1),
                DateTime.Now);

            var reportWindow = new ReportWindow { DataContext = new ReportViewModel(report) };
            reportWindow.ShowDialog();
        }

        private void UpdateTotals()
        {
            TotalIncome = 0;
            TotalExpenses = 0;

            foreach (var transaction in Transactions)
            {
                if (transaction.Type == TransactionType.Income)
                    TotalIncome += transaction.Amount;
                else
                    TotalExpenses += transaction.Amount;
            }

            NetProfit = TotalIncome - TotalExpenses;
        }

        private void LoadData()
        {
            try
            {
                var transactions = _storageService.LoadTransactions();
                Transactions.Clear();
                foreach (var transaction in transactions)
                    Transactions.Add(transaction);
                UpdateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void SaveData()
        {
            try
            {
                _storageService.SaveTransactions(new List<Transaction>(Transactions));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}