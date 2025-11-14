using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Title { get; set; }

    public string AuthorId { get; set; }

    public int Year { get; set; }

    public Book(string title, string authorId, int year)
    {
        Title = title;
        AuthorId = authorId;
        Year = year;
    }

    public override string ToString()
    {
        return $"Id: {this.Id}\n" +
               $"Id do Autor: {this.AuthorId}\n" +
               $"Título: {this.Title}\n" +
               $"Ano de publicação: {this.Year}";
    }
}