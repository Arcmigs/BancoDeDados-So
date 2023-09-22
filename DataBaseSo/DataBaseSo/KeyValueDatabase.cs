using System;
using System.Collections.Generic;
using System.IO;

namespace DataBaseSo
{
    public class KeyValueDatabase
    {
        private Dictionary<string, object> database = new Dictionary<string, object>();

        public void Inserir(string chave, object valor)
        {
            if (!database.ContainsKey(chave))
            {
                database[chave] = valor;
                Console.WriteLine($"Inserido: {chave} => {valor}");
            }
            else
            {
                Console.WriteLine("Chave já existe na base de dados.");
            }
        }

        public void Remover(string chave)
        {
            if (database.ContainsKey(chave))
            {
                database.Remove(chave);
                Console.WriteLine($"Removido: {chave}");
            }
            else
            {
                Console.WriteLine("Chave não encontrada na base de dados.");
            }
        }

        public void Atualizar(string chave, object novoValor)
        {
            if (database.ContainsKey(chave))
            {
                database[chave] = novoValor;
                Console.WriteLine($"Atualizado: {chave} => {novoValor}");
            }
            else
            {
                Console.WriteLine("Chave não encontrada na base de dados.");
            }
        }

        public object Pesquisar(string chave)
        {
            if (database.ContainsKey(chave))
            {
                return database[chave];
            }
            else
            {
                Console.WriteLine("Chave não encontrada na base de dados.");
                return null;
            }
        }

        public void SalvarParaArquivo(string nomeArquivo)
        {
            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                foreach (var kvp in database)
                {
                    writer.WriteLine($"{kvp.Key}:{kvp.Value}");
                }
            }

            Console.WriteLine($"Dados salvos em '{nomeArquivo}'.");
        }

        public void CarregarDeArquivo(string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                database.Clear();

                using (StreamReader reader = new StreamReader(nomeArquivo))
                {
                    string linha;
                    while ((linha = reader.ReadLine()) != null)
                    {
                        string[] partes = linha.Split(':');
                        if (partes.Length == 2)
                        {
                            string chave = partes[0];
                            string valor = partes[1];
                            database[chave] = valor;
                        }
                    }
                }

                Console.WriteLine($"Dados carregados de '{nomeArquivo}'.");
            }
            else
            {
                Console.WriteLine($"O arquivo '{nomeArquivo}' não existe.");
            }
        }
    }
}