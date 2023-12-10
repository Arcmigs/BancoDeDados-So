# Banco de Dados Chave-Valor em C#

Este projeto implementa um banco de dados chave-valor em C# para a disciplina de Sistemas Operacionais.

## Integrantes do Grupo
- Cauã Diniz
- Lucas Guedes
- Miguel Felipe
- Pedro César

## Funcionalidades

### KeyValueDatabase
A classe KeyValueDatabase representa o banco de dados chave-valor e oferece as seguintes funcionalidades:

#### Construtor
O construtor da classe é definido da seguinte forma:

```csharp
public KeyValueDatabase(string filePath)
Ele inicializa uma nova instância do banco de dados, utilizando persistência dos dados.

#### Métodos

##### Inserir
```csharp
public void Insert(int key, string value)
Este método insere um novo par chave-valor no banco de dados. Os parâmetros são a chave do registro e o valor associado à chave.

##### Remover
```csharp
public void Remove(int key)
O método Remove exclui um registro do banco de dados com base na chave fornecida como parâmetro.

##### Atualizar
```csharp
public void Update(int key, string newValue)
O método Update atualiza o valor associado a uma chave existente no banco de dados. São fornecidos a chave do registro a ser atualizado e o novo valor associado à chave.

##### Pesquisar
```csharp
public string Search(int key)
O método Search pesquisa e retorna o valor associado a uma chave no banco de dados. É necessário fornecer a chave do registro a ser pesquisado.

##### SalvarParaArquivo
```csharp
public void SaveToDisk()
Este método salva os dados do banco de dados em um arquivo.

##### CarregarDeArquivo
```csharp
public void LoadFromDisk()
O método LoadFromDisk carrega os dados do banco de dados a partir de um arquivo.

##### HandleRequest
```csharp
public Message HandleRequest(Message request)
O método HandleRequest lida com solicitações do cliente e retorna uma resposta. O parâmetro request é um objeto Message que representa a solicitação do cliente.

## Uso do Programa Cliente
O programa cliente interage com o banco de dados por meio de comandos. Os comandos suportados incluem:

- `insert <key,value>`
- `remove <key>`
- `update <key,new-value>`
- `search <key>`
- `quit`

### Exemplo de uso:
```plaintext
$ simpledb-client
insert 1,pedro
inserted
insert 2,banana
inserted
updated 2,apple
updated
search 3
not found
search 1
pedro
quit

**Observação:** Certifique-se de fornecer os argumentos necessários para cada comando (chave e valor quando aplicável) após a opção do comando. Mensagens de erro serão exibidas caso ocorra uma operação inválida, como inserir uma chave que já existe ou tentar remover/atualizar/pesquisar uma chave que não existe.