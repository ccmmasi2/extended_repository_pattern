namespace Pattern.Repository.Core.Models
{
    public class OrderDtlDTO
    {
        public int ID { get; set; }
        public int Qty { get; set; }
        public long Price { get; set; }
        public int OrderHdrId { get; set; }
        public int ProductId { get; set; }
        public virtual OrderHdrDTO OrderHdr { get; set; }
        public virtual ProductDTO Product { get; set; }
    }
}
