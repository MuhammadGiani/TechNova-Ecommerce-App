namespace Week_8_SCDLab.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public int Quantity { get; set; }
        public decimal StockPrice { get; set; }
    }
}
