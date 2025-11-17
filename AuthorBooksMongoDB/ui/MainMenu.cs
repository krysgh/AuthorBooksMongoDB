using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorBooksMongoDB.ui
{
    public class MainMenu
    {

        private readonly AuthorsMenu AuthorsMenu;
        private readonly BooksMenu BooksMenu; 

        public MainMenu(AuthorsMenu authorsMenu, BooksMenu booksMenu)
        {
            this.AuthorsMenu = authorsMenu;
            this.BooksMenu = booksMenu;
        }
        public async Task Run()
        {
            int mainOption;
            do
            {
                Console.Clear();
                Console.WriteLine("--- MENU PRINCIPAL ---");
                Console.WriteLine("1 - Autores");
                Console.WriteLine("2 - Livros");
                Console.WriteLine("3 - Encerrar Programa");
                Console.Write("Digite a opção desejada: ");
                mainOption = Int32.Parse(Console.ReadLine()!);

                switch(mainOption)
                {
                    case 1:
                        await AuthorsMenu.Run();
                        break;
                    case 2:
                        await BooksMenu.Run();
                        break;
                    case 3:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida. Pressione qualquer tecla para avançar.");
                        Console.ReadKey();
                        break;
                }
            } while (mainOption != 3);
        }

    }
}
