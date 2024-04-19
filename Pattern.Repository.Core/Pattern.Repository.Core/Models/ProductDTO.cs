namespace Pattern.Repository.Core.Models
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public long Price { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryDTO Category { get; set; }
        public virtual int StockQty { get; set; }
        public virtual int OrderQty { get; set; }
    }
}
