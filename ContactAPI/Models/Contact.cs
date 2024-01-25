namespace ContactAPI.Models
{
    public class Contact
    {
        public int Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public long Phone { get; set; }
        public string City { get; set; }

    }
}
