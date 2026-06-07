using System;

namespace FinanceAnalysisSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public Transaction() { }

        public Transaction(int id, string description, decimal amount, 
            TransactionType type, string category, DateTime date)
        {
            Id = id;
            Description = description;
            Amount = amount;
            Type = type;
            Category = category;
            Date = date;
        }
    }

    public enum TransactionType
    {
        Income,
        Expense
    }
}