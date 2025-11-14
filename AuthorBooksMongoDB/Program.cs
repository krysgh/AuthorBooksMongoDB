using MongoDB.Driver;

void ShowAuthors(List<Author> authors)
{
   foreach(var author in authors)
    {
        Console.WriteLine(author);
        Console.WriteLine("---");
    }
}

void ShowBooks(List<Author> authors)
{
    foreach (var author in authors)
    {
        Console.WriteLine(author);
        Console.WriteLine("---");
    }
}

var client = new MongoClient("mongodb+srv://krysthiang_db_user:2SrPPyQ9hDbfbBFJ@interacaomongo.c0dlrc6.mongodb.net/");

var database = client.GetDatabase("AuthorBooks");

var colAuthors = database.GetCollection<Author>("Authors");

var colBooks = database.GetCollection<Book>("Books");


//CRUD Authors

/*
colAuthors.InsertMany(new List<Author> {
                      new Author("Gabriel García Márquez", "Colômbia"),
                      new Author("Jane Austen","Reino Unido"),
                      new Author("Haruki Murakami","Japão"),
                      new Author("Chimamanda Ngozi Adichie","Nigéria"),
                      new Author("Jorge Amado","Brasil")}

);

ShowAuthors(await colAuthors.FindAsync(_ => true).Result.ToListAsync());
*/

/*Alterar o registro de Jorge Amado - Brasil para Machado de Assis - Brasil (Id :6917811b7b53903712dcf2fd)
colAuthors.UpdateOne(
    _ => _.Id == "6917811b7b53903712dcf2fd",
    Builders<Author>.Update
                    .Set(a => a.Name, "Machado de Assis")
);
*/

/*Deletar todos os registros que possuem país de origem: Reino Unido
colAuthors.DeleteMany(_ => _.Country == "Reino Unido");

ShowAuthors(await colAuthors.FindAsync(_ => true).Result.ToListAsync());
*/

