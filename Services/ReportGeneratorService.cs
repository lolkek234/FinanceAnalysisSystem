using System.Collections.Generic;
using System.Linq;
using FinanceAnalysisSystem.Models;

namespace FinanceAnalysisSystem.Services
{
    public class ReportGeneratorService
    {
        public string GenerateReport(List<Transaction> transactions)
        {
            var analysis = new AnalysisService().AnalyzeTransactions(transactions);
            
            var report = $"Финансовый отчет\n" +
                         $"================\n" +
                         $"Общий доход: {analysis.TotalIncome}\n" +
                         $"Общие расходы: {analysis.TotalExpense}\n" +
                         $"Прибыль: {analysis.Profit}\n" +
                         $"Количество операций: {analysis.TransactionCount}";
            
            return report;
        }
    }
}
