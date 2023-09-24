Esse é um banco de Dados Chave-Valor feito em C# para a matéria de Sistemas Operacionais
Integrantes do grupo:Cauã Diniz, Lucas Guedes, Miguel Felipe, Pedro César

Funções Disponíveis:

Inserir(string chave, object valor)

Descrição: Insere um par chave-valor no banco de dados.
Uso:
--insert chave valor
Exemplo:
--insert nome João
Resultado:
Inserido: nome => João


Remover(string chave)

Descrição: Remove um valor associado a uma chave específica no banco de dados.
Uso:
--remove chave
Exemplo:
--remove nome
Resultado:
Removido: nome


Atualizar(string chave, object novoValor)

Descrição: Atualiza o valor associado a uma chave existente no banco de dados.
Uso:
--update chave novoValor
Exemplo:
--update nome Maria
Resultado:
Atualizado: nome => Maria


Pesquisar(string chave)

Descrição: Pesquisa e retorna o valor associado a uma chave no banco de dados.
Uso:
--search chave
Exemplo:
--search nome
Resultado:
Valor: Maria


SalvarParaArquivo(string nomeArquivo)

Descrição: Salva os dados do banco de dados em um arquivo.
Uso:
--save nomeArquivo
Exemplo:
--save database.txt
Resultado:
Dados salvos em 'database.txt'.


CarregarDeArquivo(string nomeArquivo)

Descrição: Carrega os dados do banco de dados a partir de um arquivo, salvo na mesma pasto do Executavel.
Uso:
--load nomeArquivo
Exemplo:
--load database.txt
Resultado:
Dados carregados de 'database.txt'.
--exit

Descrição: Encerra o programa cliente.

Observações:

Certifique-se de fornecer os argumentos necessários para cada comando (chave e valor quando aplicável) após a opção do comando.
Mensagens de erro serão exibidas caso ocorra uma operação inválida, como inserir uma chave que já existe ou tentar remover/atualizar/pesquisar uma chave que não existe.