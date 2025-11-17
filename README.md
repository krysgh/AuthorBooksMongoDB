Projeto: Gerenciamento de Autores e Livros com MongoDB e C# (.NET 9)
Este projeto implementa um sistema CRUD (Create, Read, Update, Delete) completo para gerenciar Autores e Livros utilizando o MongoDB como banco de dados NoSQL e C# com .NET 9 (Console Application). O sistema demonstra a persistência de dados, a consulta de documentos relacionados e a interação via linha de comando.

Recursos Principais
Modelagem de Dados Simples: Duas collections (Authors e Books) com relacionamento referenciado (AuthorId em Book).

CRUD Assíncrono: Todas as operações de banco de dados são executadas de forma assíncrona (async/await) utilizando o driver oficial MongoDB.Driver.

Interface de Console: Navegação via menus interativos para todas as operações (Inserir, Listar, Atualizar, Deletar).

Validação de ID: Verificação básica do formato ObjectId (24 dígitos hexadecimais) na entrada do usuário.

Simulação de Join: A listagem de livros (ShowAllBooks) busca dinamicamente o nome do autor relacionado.

Tecnologias Utilizadas
Linguagem: C#

Framework: .NET 9 (Console Application)

Banco de Dados: MongoDB

Driver: MongoDB.Driver

Estrutura de Arquivos
O projeto está organizado em modelos (model), serviços de lógica/CRUD (service) e interface de usuário (ui).

Configuração e Execução
Pré-requisitos
: Certifique-se de ter o SDK instalado.

Servidor MongoDB: Um servidor MongoDB deve estar em execução (localmente ou acessível via conexão).

Passos para Rodar
Clonar o Repositório:

Restaurar Dependências:

Configurar Conexão (Ajuste no Program.cs)
Atenção: A linha var database = client.GetDatabase("AuthorBooks"); no seu Program.cs assume que a variável client foi definida. Você deve adicionar a inicialização do cliente MongoDB no início do seu Program.cs:

Executar a Aplicação:

O programa iniciará no Menu Principal, permitindo que você navegue entre as operações de Autores e Livros.

Detalhes da Implementação
1. Modelagem de Dados
Author: Id (ObjectId), Name, Country.

Book: Id (ObjectId), Title, AuthorId (string, referenciando o ObjectId do Autor), Year.

2. Operação de Leitura (Simulação de Join)
A funcionalidade ShowAllBooks() em BooksCRUD.cs executa a consulta para buscar os dados relacionados:

Esta abordagem é a maneira típica de desnormalizar uma consulta de relacionamento 1:N no lado da aplicação C#, onde um livro é listado, e em seguida, o autor correspondente é consultado separadamente usando o AuthorId como chave.

3. Tratamento de ID
Ambos os métodos UpdateOneAuthor/Book e DeleteOneAuthor/Book incluem um loop do-while para forçar o usuário a inserir um ID com 24 dígitos hexadecimais, que é o formato padrão do ObjectId do MongoDB, aumentando a robustez da interface.
