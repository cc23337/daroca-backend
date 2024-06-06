public class SalesOrdemItem{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public required decimal UnitPrice { get; set; }

    public decimal GetTotalPrice()
    {
        return Quantity * UnitPrice;
    }
}

