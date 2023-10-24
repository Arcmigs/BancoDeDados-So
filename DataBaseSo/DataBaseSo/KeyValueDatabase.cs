using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataBaseSO
{
    public class KeyValueDatabase
    {
        private List<KeyValueRecord> records;
        private string databaseFilePath;

        public KeyValueDatabase(string filePath)
        {
            databaseFilePath = filePath;
            LoadDataFromDisk();
        }

        public void Insert(int key, string value)
        {
            records.Add(new KeyValueRecord { Key = key, Value = value });
            SaveDataToDisk();
        }

        public void Remove(int key)
        {
            records.RemoveAll(r => r.Key == key);
            SaveDataToDisk();
        }

        public void Update(int key, string newValue)
        {
            var record = records.FirstOrDefault(r => r.Key == key);
            if (record != null)
            {
                record.Value = newValue;
                SaveDataToDisk();
            }
        }

        public string Search(int key)
        {
            var record = records.FirstOrDefault(r => r.Key == key);
            return record != null ? record.Value : "not found";
        }

        private void LoadDataFromDisk()
        {
            if (File.Exists(databaseFilePath))
            {
                string[] lines = File.ReadAllLines(databaseFilePath);
                records = lines.Select(line =>
                {
                    var parts = line.Split(',');
                    return new KeyValueRecord
                    {
                        Key = int.Parse(parts[0]),
                        Value = parts[1]
                    };
                }).ToList();
            }
            else
            {
                records = new List<KeyValueRecord>();
            }
        }

        private void SaveDataToDisk()
        {
            string[] lines = records.Select(record => $"{record.Key},{record.Value}").ToArray();
            File.WriteAllLines(databaseFilePath, lines);
        }
    }
}