public class Customer //classe de informações do cliente
{
    public required int CustomerId { get; set; } 
    public required string Name { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required decimal Latitude { get; set;}
    public required decimal Longitude { get; set;}
}