using System;
using System.Text;
using FinanceAnalysisSystem.Models;

namespace FinanceAnalysisSystem.Services
{
    public class ReportGeneratorService
    {
        public string GenerateTextReport(FinancialReport report)
        {
            var sb = new StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════");
            sb.AppendLine("    ФИНАНСОВЫЙ ОТЧЕТ");
            sb.AppendLine("═══════════════════════════════════════════");
            sb.AppendLine($"Дата отчета: {report.ReportDate:dd.MM.yyyy}");
            sb.AppendLine();

            sb.AppendLine("ОСНОВНЫЕ ПОКАЗАТЕЛИ:");
            sb.AppendLine($"├─ Общий доход:          {report.TotalIncome:C}");
            sb.AppendLine($"├─ Общие расходы:        {report.TotalExpenses:C}");
            sb.AppendLine($"├─ Чистая прибыль:       {report.NetProfit:C}");
            sb.AppendLine($"├─ Рентабельность:       {report.ReturnOnRevenue:F2}%");
            sb.AppendLine($"└─ Маржа прибыли:        {report.ProfitMargin:F2}%");
            sb.AppendLine();

            sb.AppendLine("ДОХОДЫ ПО КАТЕГОРИЯМ:");
            foreach (var item in report.IncomeByCategory)
            {
                decimal percentage = report.TotalIncome > 0 
                    ? (item.Value / report.TotalIncome) * 100 
                    : 0;
                sb.AppendLine($"├─ {item.Key}: {item.Value:C} ({percentage:F2}%)");
            }
            sb.AppendLine();

            sb.AppendLine("РАСХОДЫ ПО КАТЕГОРИЯМ:");
            foreach (var item in report.ExpenseByCategory)
            {
                decimal percentage = report.TotalExpenses > 0 
                    ? (item.Value / report.TotalExpenses) * 100 
                    : 0;
                sb.AppendLine($"├─ {item.Key}: {item.Value:C} ({percentage:F2}%)");
            }
            sb.AppendLine();
            sb.AppendLine("═══════════════════════════════════════════");

            return sb.ToString();
        }
    }
}