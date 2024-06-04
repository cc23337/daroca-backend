public class SalesOrder{
    public int OrderId{get;set;}
    public required int CustomerId {get; set; }
    public required DateTime OrderDate {get; set; }
    public DateOnly EstimatedDeliveryDate { get; set; }
    public required string Status {get; set; }

}