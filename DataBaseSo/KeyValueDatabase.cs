using DatabaseSo;
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
        
        private int maxRecords = 100;
        

        public KeyValueDatabase(string filePath)
        {
            databaseFilePath = filePath;
            LoadDataFromDisk();
        }

        public void Insert(int key, string value)
        {
            try
            {
                if (records.Any(r => r.Key == key))
                {
                    Console.WriteLine("Erro: Chave já existe. Não é possível inserir duplicatas.");
                    return;
                }
                
                if (records.Count >= maxRecords)
                {
                    
                    var oldestRecord = records.OrderBy(r => r.LastAccessed).First();
                    records.Remove(oldestRecord);
                }
                
                records.Add(new KeyValueRecord { Key = key, Value = value, LastAccessed = DateTime.Now });
                
                SaveDataToDisk();
                Console.WriteLine($"Inserido: {key} => {value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante a inserção: {ex.Message}");
            }
        }

        public void Remove(int key)
        {
            try
            {
                var removedRecord = records.RemoveAll(r => r.Key == key);
                if (removedRecord > 0)
                {
                    SaveDataToDisk();
                    Console.WriteLine($"Removido: {key}");
                }
                else
                {
                    Console.WriteLine("Erro: Chave não encontrada. Não é possível remover.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante a remoção: {ex.Message}");
            }
        }

        public void Update(int key, string newValue)
        {
            try
            {
                var record = records.FirstOrDefault(r => r.Key == key);
                if (record != null)
                {
                    record.Value = newValue;
                    
                    record.LastAccessed = DateTime.Now;
                    
                    SaveDataToDisk();
                    Console.WriteLine($"Atualizado: {key} => {newValue}");
                }
                else
                {
                    Console.WriteLine("Erro: Chave não encontrada. Não é possível atualizar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante a atualização: {ex.Message}");
            }
        }

        public string Search(int key)
        {
            try
            {
                var record = records.FirstOrDefault(r => r.Key == key);
                
                if (record != null)
                {
                    record.LastAccessed = DateTime.Now;
                    return record.Value;
                }
                else
                {
                    return "not found";
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante a pesquisa: {ex.Message}");
                return "not found";
            }
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
                        Value = parts[1],
                        LastAccessed = DateTime.Now
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

        public Message HandleRequest(Message request)
        {
            var response = new Message();
            
            Thread thread = null;
            
            switch (request.Op)
            {
                case Operation.Insert:
                    
                    thread = new Thread(() =>
                    {
                        lock (this)
                        {
                            Insert(request.Key, request.Value);
                            response.Value = "inserted";
                        }
                    });
                    
                    break;
                case Operation.Get:
                    
                    thread = new Thread(() =>
                    {
                        lock (this)
                        {
                            response.Value = Search(request.Key);
                        }
                    });
                    
                    break;
                case Operation.Update:
                    
                    thread = new Thread(() =>
                    {
                        lock (this)
                        {
                            Update(request.Key, request.Value);
                            response.Value = "updated";
                        }
                    });
                    
                    break;
                case Operation.Remove:
                    
                    thread = new Thread(() =>
                    {
                        lock (this)
                        {
                            Remove(request.Key);
                            response.Value = "removed";
                        }
                    });
                    
                    break;
            }
            
            if (thread != null)
            {
                thread.Start();
                thread.Join(); 
            }
            
            return response;
        }
    }

}