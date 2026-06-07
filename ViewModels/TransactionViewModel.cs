using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using FinanceAnalysisSystem.Models;

namespace FinanceAnalysisSystem.ViewModels
{
    public class TransactionViewModel : INotifyPropertyChanged
    {
        private string _description;
        private decimal _amount;
        private TransactionType _type;
        private string _category;
        private DateTime _date;
        private bool _isConfirmed;

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged();
                }
            }
        }

        public TransactionType Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Categories));
                    Category = null;
                }
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsConfirmed
        {
            get => _isConfirmed;
            set
            {
                if (_isConfirmed != value)
                {
                    _isConfirmed = value;
                    OnPropertyChanged();
                }
            }
        }

        public string[] Categories =>
            Type == TransactionType.Income ? Category.IncomeCategories : Category.ExpenseCategories;

        public TransactionViewModel()
        {
            Date = DateTime.Now;
            Type = TransactionType.Expense;
        }

        public void Confirm()
        {
            if (string.IsNullOrWhiteSpace(Description))
            {
                MessageBox.Show("Введите описание операции");
                return;
            }

            if (Amount <= 0)
            {
                MessageBox.Show("Сумма должна быть больше нуля");
                return;
            }

            if (string.IsNullOrWhiteSpace(Category))
            {
                MessageBox.Show("Выберите категорию");
                return;
            }

            IsConfirmed = true;
        }

        public void Cancel()
        {
            IsConfirmed = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}