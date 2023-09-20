using System;
using System.Collections.Generic;

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
                Console.WriteLine(chave,valor);
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
                Console.WriteLine(chave,novoValor);
            }
        }

        public object Pesquisar()
        {
            if (database.ContainsKey())
            {
                return database[];
            }
        }
    }
}
