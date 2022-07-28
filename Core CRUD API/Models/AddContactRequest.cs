namespace Core_CRUD_API.Models
{
    public class AddContactRequest
    {
        public string FullName { get; set; }

        public string email { get; set; }

        public long Phone { get; set; }

        public string Address { get; set; }
    }
}
