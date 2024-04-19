namespace Pattern.Repository.Core.Models
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public long Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int IdentificationTypeId { get; set; }
        public virtual IdentificationTypeDTO IdentificationType { get; set; }
    }
}
