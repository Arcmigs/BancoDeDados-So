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
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("--insert - Inserir");
                Console.WriteLine("--remove - Remover");
                Console.WriteLine("--update - Atualizar");
                Console.WriteLine("--search - Pesquisar");
                Console.WriteLine("--save - Salvar para arquivo");
                Console.WriteLine("--load - Carregar de arquivo");
                Console.WriteLine("--exit - Sair");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "--insert":
                        Console.Write("Digite a chave: ");
                        string chaveInserir = Console.ReadLine();
                        Console.Write("Digite o valor: ");
                        object valorInserir = Console.ReadLine();
                        db.Inserir(chaveInserir, valorInserir);
                        break;

                    case "--remove":
                        Console.Write("Digite a chave: ");
                        string chaveRemover = Console.ReadLine();
                        db.Remover(chaveRemover);
                        break;

                    case "--update":
                        Console.Write("Digite a chave: ");
                        string chaveAtualizar = Console.ReadLine();
                        Console.Write("Digite o novo valor: ");
                        object novoValor = Console.ReadLine();
                        db.Atualizar(chaveAtualizar, novoValor);
                        break;

                    case "--search":
                        Console.Write("Digite a chave: ");
                        string chavePesquisar = Console.ReadLine();
                        object resultado = db.Pesquisar(chavePesquisar);
                        if (resultado != null)
                        {
                            Console.WriteLine($"Valor: {resultado}");
                        }
                        break;

                    case "--save":
                        Console.Write("Digite o nome do arquivo para salvar: ");
                        string nomeArquivoSalvar = Console.ReadLine();
                        db.SalvarParaArquivo(nomeArquivoSalvar);
                        break;

                    case "--load":
                        Console.Write("Digite o nome do arquivo para carregar: ");
                        string nomeArquivoCarregar = Console.ReadLine();
                        db.CarregarDeArquivo(nomeArquivoCarregar);
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
