using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorBooksMongoDB.service
{
    public class BooksCRUD
    {
        private readonly IMongoCollection<Book> BooksCollection;

        private readonly IMongoCollection<Author> AuthorsCollection;
        public List<Book> Books { get; set; }

        public BooksCRUD(IMongoCollection<Book> booksCollection, IMongoCollection<Author> authorsCollection)
        {
            this.BooksCollection = booksCollection;
            this.AuthorsCollection = authorsCollection;
        }

        public async Task InsertBook()
        {
            int repeat = 0;
            bool repeatIdTreatment;
            string idAuthor;
            Books = new List<Book>();

            do
            {
                Console.Clear();
                Console.WriteLine("----- INSERIR LIVRO -----");

                do
                {
                    repeatIdTreatment = false;
                    Console.Write("Informe o id do autor do livro: ");

                    idAuthor = Console.ReadLine()!;

                    if (idAuthor.Length != 24)
                    {
                        AlertMessage("INSIRA UM ID DE 24 DIGITOS HEX!");
                        repeatIdTreatment = true;
                    }
                } while (repeatIdTreatment);

                if (await AuthorsCollection.Find(_ => _.Id == idAuthor).AnyAsync())
                {
                    Console.Write("Informe o título do livro: ");
                    var title = Console.ReadLine()!;
                    Console.Write("Informe o ano de publicação do livro: ");
                    int year = Int32.Parse(Console.ReadLine()!);

                    Books.Add(new Book(title, idAuthor, year));

                    Console.Clear();
                    PositiveMessage("LIVRO ADICIONADO COM SUCESSO!");

                    Console.WriteLine("Deseja inserir outro livro?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    Console.Write("Digite a opção desejada: ");
                    repeat = Int32.Parse(Console.ReadLine()!);
                }
                else
                {
                    ErrorMessage("AUTOR NÃO ENCONTRADO!");
                    Console.WriteLine("Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    repeat = 1;
                }

            } while (repeat == 1);

            await BooksCollection.InsertManyAsync(Books);

        }

        public async Task<bool> FindBookById(string id)
        {
            return await BooksCollection.Find(_ => _.Id == id).AnyAsync();
        }

        public async Task ShowAllBooks()
        {
            Console.Clear();
            Console.WriteLine("----- LISTA DE LIVROS -----");

            Books = await BooksCollection.Find(_ => true).ToListAsync();

            if (Books.Count > 0)
                foreach (var book in Books)
                {
                    Console.WriteLine(book);
                    Console.WriteLine("\nDados do autor:");
                    Console.WriteLine(await AuthorsCollection.Find(_ => _.Id == book.AuthorId).FirstOrDefaultAsync());
                    Console.WriteLine("---");
                }
            else
                Console.WriteLine("Não há livros nessa lista.");
            Console.WriteLine("Pressione qualquer tecla para voltar para Livros.");
            Console.ReadKey();
        }

        public async Task UpdateOneBook()
        {
            int repeat = 0;
            do
            {
                int repeatIdTreatment;
                string id;

                Console.Clear();
                Console.WriteLine("----- ALTERAR LIVRO -----");

                do
                {
                    repeatIdTreatment = 0;
                    Console.Write("Informe o id do livro a ser atualizado: ");

                    id = Console.ReadLine()!;

                    if (id.Length != 24)
                    {
                        AlertMessage("INSIRA UM ID DE 24 DIGITOS HEX!");
                        repeatIdTreatment = 1;
                    }
                } while (repeatIdTreatment == 1);


                if (await FindBookById(id))
                {
                    PositiveMessage("LIVRO ENCONTRADO!");


                    string idAuthor;

                    do
                    {
                        repeatIdTreatment = 0;
                        Console.Write("Informe o id do autor do livro: ");

                        idAuthor = Console.ReadLine()!;

                        if (idAuthor.Length != 24)
                        {
                            AlertMessage("INSIRA UM ID DE 24 DIGITOS HEX!");
                            repeatIdTreatment = 1;
                        }
                    } while (repeatIdTreatment == 1);

                    if (await AuthorsCollection.Find(_ => _.Id == idAuthor).AnyAsync())
                    {

                        Console.Write("Informe o título do livro: ");
                        var title = Console.ReadLine()!;

                        Console.Write("Informe o ano de publicação do livro: ");
                        int year = Int32.Parse(Console.ReadLine()!);

                        await BooksCollection.UpdateOneAsync(_ => _.Id == id,
                                             Builders<Book>.Update
                                             .Set(_ => _.Title, title)
                                             .Set(_ => _.AuthorId, idAuthor)
                                             .Set(_ => _.Year, year));

                        PositiveMessage("LIVRO ATUALIZADO COM SUCESSO!");

                        Console.WriteLine("Deseja atualizar outro livro?");
                        Console.WriteLine("1 - Sim");
                        Console.WriteLine("2 - Não");
                        Console.Write("Digite a opção desejada: ");
                        repeat = Int32.Parse(Console.ReadLine()!);
                    }
                    else
                    {
                        ErrorMessage("AUTOR NÃO ENCONTRADO!");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        repeat = 1;
                    }
                }
                else
                {
                    ErrorMessage("LIVRO NÃO ENCONTRADO!");

                    Console.WriteLine("Deseja tentar novamente?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    Console.Write("Digite a opção desejada: ");
                    repeat = Int32.Parse(Console.ReadLine()!);
                }

                } while (repeat == 1) ;


            }


        public async Task DeleteOneBook()
        {
            int repeat = 0;
            do
            {
                int repeatIdTreatment;
                string id;

                Console.Clear();
                Console.WriteLine("----- DELETAR LIVRO -----");

                do
                {
                    repeatIdTreatment = 0;
                    Console.Write("Informe o id do livro a ser deletado: ");

                    id = Console.ReadLine()!;

                    if (id.Length != 24)
                    {
                        AlertMessage("INSIRA UM ID DE 24 DIGITOS HEX!");
                        repeatIdTreatment = 1;
                    }
                } while (repeatIdTreatment == 1);


                if (await FindBookById(id))
                {
                    PositiveMessage("LIVRO ENCONTRADO!");
                    
                    var book = await BooksCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();

                    Console.WriteLine(book);
                    AlertMessage("Deseja realmente deletar este livro?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    Console.Write("Digite a opção desejada: ");
                    var option = Int32.Parse(Console.ReadLine()!);

                    switch (option)
                    {
                        case 1:
                            await BooksCollection.DeleteOneAsync(_ => _.Id == id);

                            PositiveMessage("LIVRO DELETADO COM SUCESSO!");

                            Console.WriteLine("Deseja deletar outro livro?");
                            Console.WriteLine("1 - Sim");
                            Console.WriteLine("2 - Não");
                            Console.Write("Digite a opção desejada: ");
                            repeat = Int32.Parse(Console.ReadLine()!);
                            break;
                        case 2:
                            repeat = 1;
                            break;
                        default:
                            Console.WriteLine("Digite uma opção válida.");
                            repeat = 1;
                            break;
                    }

                    
                }
                else
                {
                    ErrorMessage("LIVRO NÃO ENCONTRADO!");

                    Console.WriteLine("Deseja tentar novamente?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    Console.Write("Digite a opção desejada: ");
                    repeat = Int32.Parse(Console.ReadLine()!);
                }

            } while (repeat == 1);

        }

        public void PositiveMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void AlertMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }


    }
}
