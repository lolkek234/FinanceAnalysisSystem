namespace FinanceAnalysisSystem.Models
{
    public class FinancialReport
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Profit => TotalIncome - TotalExpense;
        public int TransactionCount { get; set; }
    }
}
