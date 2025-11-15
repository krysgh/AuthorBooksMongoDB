using AuthorBooksMongoDB.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorBooksMongoDB.ui
{
    public class AuthorsMenu
    {

        public static void Main()
        {
            int mainOption;
            do
            {
                Console.Clear();
                Console.WriteLine("--- AUTORES ---");
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
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:
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

