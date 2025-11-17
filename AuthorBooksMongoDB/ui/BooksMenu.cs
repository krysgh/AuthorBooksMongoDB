using AuthorBooksMongoDB.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorBooksMongoDB.ui
{
    public class BooksMenu
    {
        public BooksCRUD BooksControl { get; set; }

        public BooksMenu(BooksCRUD booksControl)
        {
            this.BooksControl = booksControl;
        }

        public async Task Run()
        {
            int mainOption;
            do
            {
                Console.Clear();
                Console.WriteLine("--- LIVROS ---");
                Console.WriteLine("1 - Inserir");
                Console.WriteLine("2 - Listar");
                Console.WriteLine("3 - Atualizar");
                Console.WriteLine("4 - Deletar");
                Console.WriteLine("5 - Voltar para o Menu Principal");
                Console.Write("Digite a opção desejada: ");
                mainOption = Int32.Parse(Console.ReadLine()!);

                switch (mainOption)
                {
                    case 1:
                        await BooksControl.InsertBook();
                        break;
                    case 2:
                        await BooksControl.ShowAllBooks();
                        break;
                    case 3:
                        await BooksControl.UpdateOneBook();
                        break;
                    case 4:
                        await BooksControl.DeleteOneBook();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida. Pressione qualquer tecla para avançar.");
                        Console.ReadKey();
                        break;
                }



            } while (mainOption != 5);
        }
    }
}
