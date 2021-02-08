namespace Core.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Governorate { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Details { get; set; }
          
    }
}