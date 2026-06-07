using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using FinanceAnalysisSystem.Models;

namespace FinanceAnalysisSystem.Services
{
    public class DataStorageService
    {
        private const string DataFile = "transactions.xml";

        public void SaveTransactions(List<Transaction> transactions)
        {
            var serializer = new XmlSerializer(typeof(List<Transaction>));
            using (var writer = new StreamWriter(DataFile))
            {
                serializer.Serialize(writer, transactions);
            }
        }

        public List<Transaction> LoadTransactions()
        {
            if (!File.Exists(DataFile))
                return new List<Transaction>();

            var serializer = new XmlSerializer(typeof(List<Transaction>));
            using (var reader = new StreamReader(DataFile))
            {
                return (List<Transaction>?)serializer.Deserialize(reader) ?? new List<Transaction>();
            }
        }
    }
}
