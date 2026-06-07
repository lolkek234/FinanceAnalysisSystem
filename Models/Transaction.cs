using System;

namespace FinanceAnalysisSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; } = string.Empty;
    }

    public enum TransactionType
    {
        Income,
        Expense
    }
}
