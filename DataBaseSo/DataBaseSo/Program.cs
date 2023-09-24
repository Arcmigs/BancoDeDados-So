using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseSo
{
    public static class ProgramClient
    {
        public static void Main(string[] args)
        {
            KeyValueDatabase db = new KeyValueDatabase();
            bool continuar = true;

            Console.WriteLine("Bem-vindo ao Programa Cliente do Banco de Dados de Chave-Valor!");

            while (continuar)
            {
                string input = Console.ReadLine();
                string[] opcaoArgs = input.Split(' ');

                switch (opcaoArgs[0])
                {
                    case "--insert":
                        if (opcaoArgs.Length == 3)
                        {
                            string chaveInserir = opcaoArgs[1];
                            object valorInserir = opcaoArgs[2];
                            db.Inserir(chaveInserir, valorInserir);
                        }
                        break;

                    case "--remove":
                        if (opcaoArgs.Length == 2)
                        {
                            string chaveRemover = opcaoArgs[1];
                            db.Remover(chaveRemover);
                        }
                        break;

                    case "--update":
                        if (opcaoArgs.Length == 3)
                        {
                            string chaveAtualizar = opcaoArgs[1];
                            object novoValor = opcaoArgs[2];
                            db.Atualizar(chaveAtualizar, novoValor);
                        }
                        break;

                    case "--search":
                        if (opcaoArgs.Length == 2)
                        {
                            string chavePesquisar = opcaoArgs[1];
                            object resultado = db.Pesquisar(chavePesquisar);
                            if (resultado != null)
                            {
                                Console.WriteLine($"Valor: {resultado}");
                            }
                        }
                        break;

                    case "--save":
                        if (opcaoArgs.Length == 2)
                        {
                            string nomeArquivoSalvar = opcaoArgs[1];
                            db.SalvarParaArquivo(nomeArquivoSalvar);
                        }
                        break;

                    case "--load":
                        if (opcaoArgs.Length == 2)
                        {
                            string nomeArquivoCarregar = opcaoArgs[1];
                            db.CarregarDeArquivo(nomeArquivoCarregar);
                        }
                        break;

                    case "--exit":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Escolha novamente.");
                        break;
                }
            }

            Console.WriteLine("Programa encerrado.");
        }
    }
}
