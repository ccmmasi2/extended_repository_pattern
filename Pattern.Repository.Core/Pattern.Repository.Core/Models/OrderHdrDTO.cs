namespace Pattern.Repository.Core.Models
{
    public class OrderHdrDTO
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string ShippingAddress { get; set; }
        public virtual CustomerDTO Customer { get; set; }
    }
}
