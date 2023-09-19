using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseSo
{
    class ProgramClient
    {
        static void Main(string[] args)
        {
            // Criar uma classe KeyValueDatabase e instanciar
            bool continuar = true;

            Console.WriteLine("Bem-vindo ao Programa Cliente do Banco de Dados de Chave-Valor!");

            while (continuar)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Inserir");
                Console.WriteLine("2 - Remover");
                Console.WriteLine("3 - Atualizar");
                Console.WriteLine("4 - Pesquisar");
                Console.WriteLine("5 - Salvar para arquivo");
                Console.WriteLine("6 - Carregar de arquivo");
                Console.WriteLine("7 - Sair");

                int opcao;
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.Write("Digite a chave: ");
                            string chaveInserir = Console.ReadLine();
                            Console.Write("Digite o valor: ");
                            object valorInserir = Console.ReadLine();
                            //passar os parâmetros pegos a cima
                            break;

                        case 2:
                            Console.Write("Digite a chave: ");
                            string chaveRemover = Console.ReadLine();
                            //passar os parâmetros pegos a cima
                            break;

                        case 3:
                            Console.Write("Digite a chave: ");
                            string chaveAtualizar = Console.ReadLine();
                            Console.Write("Digite o novo valor: ");
                            object novoValor = Console.ReadLine();
                            //passar os parâmetros pegos a cima
                            break;

                        case 4:
                            Console.Write("Digite a chave: ");
                            string chavePesquisar = Console.ReadLine();
                            /*object resultado = passar os parâmetros pegos a cima
                            if (resultado != null)
                            {
                                Console.WriteLine($"Valor: {resultado}");
                            }*/
                            break;

                        case 5:
                            Console.Write("Digite o nome do arquivo para salvar: ");
                            string nomeArquivoSalvar = Console.ReadLine();
                            //passar os parâmetros pegos a cima
                            break;

                        case 6:
                            Console.Write("Digite o nome do arquivo para carregar: ");
                            string nomeArquivoCarregar = Console.ReadLine();
                            //passar os parâmetros pegos a cima
                            break;

                        case 7:
                            continuar = false;
                            break;

                        default:
                            Console.WriteLine("Opção inválida. Escolha novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Escolha novamente.");
                }
            }

            Console.WriteLine("Programa encerrado.");
        }
    }
}
