using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FinanceAnalysisSystem.Models;
using FinanceAnalysisSystem.Services;

namespace FinanceAnalysisSystem.ViewModels
{
    public class ReportViewModel : INotifyPropertyChanged
    {
        private readonly FinancialReport _report;
        private string _reportText;

        public FinancialReport Report => _report;

        public string ReportText
        {
            get => _reportText;
            set
            {
                if (_reportText != value)
                {
                    _reportText = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal TotalIncome => _report.TotalIncome;
        public decimal TotalExpenses => _report.TotalExpenses;
        public decimal NetProfit => _report.NetProfit;
        public decimal ProfitMargin => _report.ProfitMargin;
        public decimal ReturnOnRevenue => _report.ReturnOnRevenue;

        public ReportViewModel(FinancialReport report)
        {
            _report = report;
            GenerateReport();
        }

        private void GenerateReport()
        {
            var generator = new ReportGeneratorService();
            ReportText = generator.GenerateTextReport(_report);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}