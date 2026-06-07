using System;
using System.Collections.Generic;
using System.Linq;
using FinanceAnalysisSystem.Models;

namespace FinanceAnalysisSystem.Services
{
    public class AnalysisService
    {
        public FinancialReport GenerateReport(List<Transaction> transactions, 
            DateTime startDate, DateTime endDate)
        {
            var report = new FinancialReport();
            var filteredTransactions = transactions
                .Where(t => t.Date >= startDate && t.Date <= endDate)
                .ToList();

            var incomeTransactions = filteredTransactions.Where(t => t.Type == TransactionType.Income).ToList();
            var expenseTransactions = filteredTransactions.Where(t => t.Type == TransactionType.Expense).ToList();

            report.TotalIncome = incomeTransactions.Sum(t => t.Amount);
            report.TotalExpenses = expenseTransactions.Sum(t => t.Amount);
            report.NetProfit = report.TotalIncome - report.TotalExpenses;

            if (report.TotalIncome > 0)
            {
                report.ProfitMargin = (report.NetProfit / report.TotalIncome) * 100;
                report.ReturnOnRevenue = (report.NetProfit / report.TotalIncome) * 100;
            }

            foreach (var transaction in incomeTransactions)
            {
                if (report.IncomeByCategory.ContainsKey(transaction.Category))
                    report.IncomeByCategory[transaction.Category] += transaction.Amount;
                else
                    report.IncomeByCategory[transaction.Category] = transaction.Amount;
            }

            foreach (var transaction in expenseTransactions)
            {
                if (report.ExpenseByCategory.ContainsKey(transaction.Category))
                    report.ExpenseByCategory[transaction.Category] += transaction.Amount;
                else
                    report.ExpenseByCategory[transaction.Category] = transaction.Amount;
            }

            return report;
        }

        public List<Transaction> GetTransactionsByCategory(List<Transaction> transactions, 
            string category)
        {
            return transactions.Where(t => t.Category == category).ToList();
        }

        public List<Transaction> GetTransactionsByDateRange(List<Transaction> transactions, 
            DateTime startDate, DateTime endDate)
        {
            return transactions
                .Where(t => t.Date >= startDate && t.Date <= endDate)
                .OrderByDescending(t => t.Date)
                .ToList();
        }
    }
}