using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Author
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    public string Country { get; set; }

    public Author(string name, string country)
    {
        Name = name;
        Country = country;
    }

    public override string? ToString()
    {
        return $"Id: {this.Id}\n" +
               $"Nome: {this.Name}\n" +
               $"País de origem: {this.Country}";
    }
}