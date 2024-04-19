namespace Pattern.Repository.Core.Models
{
    public class StockDTO
    {
        public int ID { get; set; }
        public int Qty { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDTO Product { get; set; }
    }
}
