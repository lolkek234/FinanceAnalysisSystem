using System;
using System.Collections.Generic;

namespace FinanceAnalysisSystem.Models
{
    public class FinancialReport
    {
        public DateTime ReportDate { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetProfit { get; set; }
        public decimal ProfitMargin { get; set; }
        public decimal ReturnOnRevenue { get; set; }
        public Dictionary<string, decimal> IncomeByCategory { get; set; }
        public Dictionary<string, decimal> ExpenseByCategory { get; set; }

        public FinancialReport()
        {
            IncomeByCategory = new Dictionary<string, decimal>();
            ExpenseByCategory = new Dictionary<string, decimal>();
            ReportDate = DateTime.Now;
        }
    }
}