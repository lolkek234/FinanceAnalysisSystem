using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FinanceAnalysisSystem.Models;

namespace FinanceAnalysisSystem.Services
{
    public class DataStorageService
    {
        private readonly string _filePath;
        private const string FileName = "transactions.json";

        public DataStorageService()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appFolder = Path.Combine(documentsPath, "FinanceAnalysisSystem");
            
            if (!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);

            _filePath = Path.Combine(appFolder, FileName);
        }

        public void SaveTransactions(List<Transaction> transactions)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(transactions, options);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        public List<Transaction> LoadTransactions()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new List<Transaction>();

                string json = File.ReadAllText(_filePath);
                
                if (string.IsNullOrWhiteSpace(json))
                    return new List<Transaction>();

                var transactions = JsonSerializer.Deserialize<List<Transaction>>(json);
                return transactions ?? new List<Transaction>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при загрузке данных: {ex.Message}");
            }
        }
    }
}