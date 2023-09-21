using System;
using System.Collections.Generic;
using System.IO;

namespace BancoDeDadosSO
{
    public class KeyValueDatabase
    {
        private Dictionary<string, object> database = new Dictionary<string, object>();

        public void Inserir(string chave, object valor)
        {
            if (!database.ContainsKey(chave))
            {
                database[chave] = valor;
                Console.WriteLine(valor);
            }
        }

        public void Remover(string chave)
        {
            if (database.ContainsKey(chave))
            {
                database.Remove(chave);
                Console.WriteLine(chave);
            }                     
        }

        public void Atualizar(string chave, object novoValor)
        {
            if (database.ContainsKey(chave))
            {
                database[chave] = novoValor;
                Console.WriteLine(novoValor);
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

            Console.WriteLine(nomeArquivo);
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

                Console.WriteLine(nomeArquivo);
            }
            else
            {
                Console.WriteLine(nomeArquivo);
            }
        }
    }
}