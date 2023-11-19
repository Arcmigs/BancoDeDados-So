# Banco de Dados Chave-Valor em C#

Este é um projeto de banco de dados chave-valor desenvolvido em C# como parte da disciplina de Sistemas Operacionais.

## Integrantes do Grupo
- Cauã Diniz
- Lucas Guedes
- Miguel Felipe
- Pedro César

## Estrutura do Projeto
O projeto está organizado em duas partes principais: `DataBaseSo` e `ServerDataBaseSo`. A primeira parte contém a implementação do banco de dados chave-valor e do cliente, enquanto a segunda parte contém a implementação do servidor.

### `DataBaseSo`
#### `KeyValueDatabase`
- **`KeyValueDatabase`**: Classe principal que representa o banco de dados chave-valor.
  - **Métodos Principais:**
    - `Insert(int key, string value)`: Insere um par chave-valor no banco de dados.
    - `Remove(int key)`: Remove um valor associado a uma chave específica no banco de dados.
    - `Update(int key, string newValue)`: Atualiza o valor associado a uma chave existente no banco de dados.
    - `Search(int key)`: Pesquisa e retorna o valor associado a uma chave no banco de dados.
  - **Métodos Adicionais:**
    - `LoadDataFromDisk()`: Carrega os dados do banco de dados a partir do arquivo.
    - `SaveDataToDisk()`: Salva os dados do banco de dados em um arquivo.
    - `HandleRequest(Message request)`: Processa uma solicitação do cliente.

#### `Message`
- **`Message`**: Classe que representa uma mensagem usada para comunicação entre cliente e servidor.
  - **Propriedades:**
    - `Op`: Operação a ser realizada (Insert, Get, Update, Remove).
    - `Key`: Chave associada à operação.
    - `Value`: Valor associado à operação.

#### `KeyValueRecord`
- **`KeyValueRecord`**: Classe que representa um registro chave-valor no banco de dados.
  - **Propriedades:**
    - `Key`: Chave do registro.
    - `Value`: Valor associado à chave.

### `Client`
- **`Client`**: Aplicativo cliente que interage com o servidor via Named Pipes.
  - **Comandos suportados:**
    - `--insert key value`: Insere um objeto no banco de dados.
    - `--get key`: Obtém um objeto do banco de dados.
    - `--update key value`: Atualiza um objeto no banco de dados.
    - `--remove key`: Remove um objeto do banco de dados.

### `ServerDataBaseSo`
#### `KeyValueDatabase`
- **`KeyValueDatabase`**: Classe que representa o banco de dados chave-valor no servidor.
  - **Métodos e Propriedades:**
    - Igual à implementação no cliente.

#### `Message`
- **`Message`**: Classe que representa uma mensagem usada para comunicação entre cliente e servidor.
  - Igual à implementação no cliente.

#### `KeyValueRecord`
- **`KeyValueRecord`**: Classe que representa um registro chave-valor no banco de dados.
  - Igual à implementação no cliente.

### `Server`
- **`Server`**: Aplicativo servidor que recebe comandos do cliente via Named Pipes e interage com o banco de dados.
  - **Como usar:**
    - `Server [caminho_do_banco_de_dados]`
    - Exemplo: `Server database.txt`

## Como Executar
1. Compile os projetos `DataBaseSo` e `ServerDataBaseSo`.
2. Execute o servidor no terminal: `Server [caminho_do_banco_de_dados]`.
3. Execute o cliente no terminal com os comandos desejados.

## Observações

- Certifique-se de fornecer os argumentos necessários para cada comando (chave e valor quando aplicável) após a opção do comando.
- Mensagens de erro serão exibidas caso ocorra uma operação inválida, como inserir uma chave que já existe ou tentar remover/atualizar/pesquisar uma chave que não existe.

---
