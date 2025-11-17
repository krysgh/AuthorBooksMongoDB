# 📚 Projeto: Gerenciamento de Autores e Livros com MongoDB e C# (.NET 9)

Este projeto implementa um sistema **CRUD completo** para gerenciar
**Autores** e **Livros**, utilizando **MongoDB** como banco NoSQL e **C#
(.NET 9)** em uma **Console Application**.\
Ele demonstra persistência de dados, consultas relacionadas e interação
via menu no terminal.

------------------------------------------------------------------------

## ✨ Recursos Principais

### 🔹 Modelagem de Dados Simples

-   Duas *collections*: `Authors` e `Books`
-   Relacionamento **1:N** utilizando referência (`AuthorId` em `Book`)

### 🔹 CRUD Assíncrono

-   Todas as operações utilizam **async/await**
-   Driver oficial **MongoDB.Driver**

### 🔹 Interface de Console

-   Navegação por **menus interativos**
-   Operações: Inserir, Listar, Atualizar e Deletar

### 🔹 Validação de ObjectId

-   Entrada do usuário validada para garantir formato correto (24
    caracteres hexadecimais)

### 🔹 Simulação de Join

-   A listagem de livros busca dinamicamente o **nome do autor**
    correspondente

------------------------------------------------------------------------

## 🛠️ Tecnologias Utilizadas

  Tecnologia           Descrição
  -------------------- ------------------------
  **C#**               Linguagem principal
  **.NET 9**           Console Application
  **MongoDB**          Banco NoSQL
  **MongoDB.Driver**   Driver oficial para C#

------------------------------------------------------------------------

## 📁 Estrutura do Projeto

    /model      → Classes Author e Book
    /service    → Lógica e operações CRUD
    /ui         → Menus e interação com o usuário
    Program.cs  → Ponto de entrada do sistema

------------------------------------------------------------------------

## ⚙️ Configuração e Execução

### ✅ Pré-requisitos

-   .NET SDK 9 instalado
-   Servidor **MongoDB** em execução (local ou remoto)

### 🚀 Passos para Rodar

#### 1️⃣ Clonar o repositório

``` bash
git clone <seu-repositorio>
cd <pasta-do-projeto>
```

#### 2️⃣ Restaurar dependências

``` bash
dotnet restore
```

#### 3️⃣ Configurar conexão no `Program.cs`

``` csharp
var client = new MongoClient("mongodb://localhost:27017");
var database = client.GetDatabase("AuthorBooks");
```

#### 4️⃣ Executar o projeto

``` bash
dotnet run
```

------------------------------------------------------------------------

## 🧩 Modelagem de Dados

### 📌 Author

-   `Id` (ObjectId)
-   `Name`
-   `Country`

### 📌 Book

-   `Id` (ObjectId)
-   `Title`
-   `AuthorId` (string -- referência ao Author)
-   `Year`

------------------------------------------------------------------------

## 🔍 Simulação de "Join" no C

A função `ShowAllBooks()` realiza:

1.  Consulta de todos os livros\
2.  Para cada livro, consulta do autor correspondente usando `AuthorId`

------------------------------------------------------------------------

## 🛡️ Tratamento de IDs

-   Validação de **24 caracteres hexadecimais**
-   Uso de `do/while` para garantir input correto

------------------------------------------------------------------------

## 📌 Conclusão

Este projeto é ideal para quem deseja aprender:

-   CRUD com MongoDB + C#
-   Relacionamentos no MongoDB
-   Uso de async/await
-   Estrutura limpa em camadas

Sinta-se à vontade para expandir o projeto!
