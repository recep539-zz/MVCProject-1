namespace AdvancedRepository.DTOs
{
    public class CustomerList
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string FullAddress { get; set; }
        public int PhoneNumber { get; set; }
        public int Rating { get; set; }
        public bool Deleted { get; set; }
    }
}
