using System;
using System.Collections.Generic;
using System.Linq;
using FinanceAnalysisSystem.Models;

namespace FinanceAnalysisSystem.Services
{
    public class AnalysisService
    {
        public FinancialReport AnalyzeTransactions(List<Transaction> transactions)
        {
            var report = new FinancialReport
            {
                TotalIncome = transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount),
                TotalExpense = transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount),
                TransactionCount = transactions.Count
            };
            return report;
        }
    }
}
