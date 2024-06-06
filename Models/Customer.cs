public class Customer //classe de informações do cliente
{
    public required int CustomerId { get; set; } 
    public required string Name { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public decimal Latitude { get; set;}
    public decimal Longitude { get; set;}

    public void UpdateAddress(string newCity, string newState)
    {
        City = newCity;
        State = newState;
    }
}

