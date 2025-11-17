using AuthorBooksMongoDB.service;
using AuthorBooksMongoDB.ui;
using MongoDB.Driver;
using System.ComponentModel.Design;

var client = new MongoClient("mongodb+srv://krysthiang_db_user:2SrPPyQ9hDbfbBFJ@interacaomongo.c0dlrc6.mongodb.net/");

var database = client.GetDatabase("AuthorBooks");

var colAuthors = database.GetCollection<Author>("Authors");

var colBooks = database.GetCollection<Book>("Books");


MainMenu mainMenu = new MainMenu(new AuthorsMenu(new AuthorsCRUD(colAuthors)), 
                    new BooksMenu(new BooksCRUD(colBooks,colAuthors)));

await mainMenu.Run();


#region Test
//CRUD Authors

/*
colAuthors.InsertMany(new List<Author> {
                      new Author("Gabriel García Márquez", "Colômbia"),
                      new Author("Jane Austen","Reino Unido"),
                      new Author("Haruki Murakami","Japão"),
                      new Author("Chimamanda Ngozi Adichie","Nigéria"),
                      new Author("Jorge Amado","Brasil")}

);

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

*/
#endregion
