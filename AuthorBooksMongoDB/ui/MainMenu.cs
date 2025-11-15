using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorBooksMongoDB.ui
{
    public class MainMenu
    {

        private readonly AuthorsMenu _authorsMenu;
        private readonly BooksMenu _booksMenu; 

        public MainMenu(AuthorsMenu authorsMenu, BooksMenu booksMenu)
        {
            _authorsMenu = authorsMenu;
            _booksMenu = booksMenu;
        }
        public void Run()
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
                        //_authorsMenu.Run();
                        break;
                    case 2:
                        //_booksMenu.Run();
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
