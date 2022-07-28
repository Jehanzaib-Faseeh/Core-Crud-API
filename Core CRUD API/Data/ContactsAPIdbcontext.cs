using Core_CRUD_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_CRUD_API.Data
{
    public class ContactsAPIdbcontext : DbContext
    {
        public ContactsAPIdbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }

}
