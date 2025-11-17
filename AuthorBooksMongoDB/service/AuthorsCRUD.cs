using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace AuthorBooksMongoDB.service
{
    public class AuthorsCRUD
    {
        private readonly IMongoCollection<Author> collection;
        public List<Author> Authors { get; set; }

        public AuthorsCRUD(IMongoCollection<Author> collection)
        {
            this.collection = collection;
        }

        public async Task InsertAuthor()
        {
            Authors = new List<Author>();
            int repeat = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("----- INSERIR AUTOR -----");
                Console.Write("Informe o nome do autor: ");
                var name = Console.ReadLine()!;
                Console.Write("Informe o país de origem do autor: ");
                var country = Console.ReadLine()!;

                Authors.Add(new Author(name, country));

                Console.Clear();
                PositiveMessage("AUTOR ADICIONADO COM SUCESSO!");


                Console.WriteLine("Deseja inserir outro autor?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");
                Console.Write("Digite a opção desejada: ");
                repeat = Int32.Parse(Console.ReadLine()!);


            } while (repeat == 1);

            await collection.InsertManyAsync(Authors);
            
        }

        public async Task<bool> FindAuthorById(string id)
        {
            return await collection.Find(_ => _.Id == id).AnyAsync();
        }

        public async Task ShowAllAuthors()
        {
            Console.Clear();
            Console.WriteLine("----- LISTA DE AUTORES -----");

            Authors = await collection.Find(_ => true).ToListAsync();

            if(Authors.Count > 0)
            foreach (var author in Authors)
            {
                Console.WriteLine(author);
                Console.WriteLine("---");
            }
            else
                Console.WriteLine("Não há autores nessa lista.");
            Console.WriteLine("Pressione qualquer tecla para voltar para Autores.");
            Console.ReadKey();
        }

        public async Task UpdateOneAuthor()
        {
            int repeat = 0;
            do
            {
                int repeatIdTreatment;
                string id;

                Console.Clear();
                Console.WriteLine("----- ALTERAR AUTOR -----");
                
                do
                {
                    repeatIdTreatment = 0;
                    Console.Write("Informe o id do autor a ser atualizado: ");

                    id = Console.ReadLine()!;

                    if (id.Length != 24)
                    {
                        AlertMessage("INSIRA UM ID DE 24 DIGITOS HEX!");
                        repeatIdTreatment = 1;
                    }
                }while(repeatIdTreatment == 1);
                

                if (await FindAuthorById(id))
                {
                    PositiveMessage("AUTOR ENCONTRADO!");

                    Console.Write("Informe o nome do autor: ");
                    var name = Console.ReadLine()!;
                    Console.Write("Informe o país de origem do autor: ");
                    var country = Console.ReadLine()!;

                    await collection.UpdateOneAsync(_ => _.Id == id,
                                         Builders<Author>.Update
                                         .Set(_ => _.Name,name)
                                         .Set(_ => _.Country,country));

                    PositiveMessage("AUTOR ATUALIZADO COM SUCESSO!");

                    Console.WriteLine("Deseja atualizar outro autor?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    Console.Write("Digite a opção desejada: ");
                    repeat = Int32.Parse(Console.ReadLine()!);
                }
                else
                {
                    ErrorMessage("AUTOR NÃO ENCONTRADO!");

                    Console.WriteLine("Deseja tentar novamente?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    Console.Write("Digite a opção desejada: ");
                    repeat = Int32.Parse(Console.ReadLine()!);
                }

            } while (repeat == 1);
        }

        public async Task DeleteOneAuthor()
        {
            int repeat = 0;
            do
            {
                int repeatIdTreatment;
                string id;

                Console.Clear();
                Console.WriteLine("----- DELETAR AUTOR -----");

                do
                {
                    repeatIdTreatment = 0;
                    Console.Write("Informe o id do autor a ser deletado: ");

                    id = Console.ReadLine()!;

                    if (id.Length != 24)
                    {
                        AlertMessage("INSIRA UM ID DE 24 DIGITOS HEX!");
                        repeatIdTreatment = 1;
                    }
                } while (repeatIdTreatment == 1);


                if (await FindAuthorById(id))
                {
                    PositiveMessage("AUTOR ENCONTRADO!");

                    var author = collection.Find(_ => _.Id == id).FirstOrDefault();

                    Console.WriteLine(author);
                    AlertMessage("Deseja realmente deletar este autor?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    Console.Write("Digite a opção desejada: ");
                    var option = Int32.Parse(Console.ReadLine()!);

                    switch (option)
                    {
                        case 1:
                            await collection.DeleteOneAsync(_ => _.Id == id);

                            PositiveMessage("AUTOR DELETADO COM SUCESSO!");

                            Console.WriteLine("Deseja deletar outro autor?");
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
                    ErrorMessage("AUTOR NÃO ENCONTRADO!");

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
