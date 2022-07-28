using Core_CRUD_API.Data;
using Core_CRUD_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_CRUD_API.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsAPIdbcontext dbContext;

        public ContactsController(ContactsAPIdbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContacts([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }


        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                FullName = addContactRequest.FullName,
                email = addContactRequest.email,
                Phone = addContactRequest.Phone,
                Address = addContactRequest.Address
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }
        
        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
            
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            { 
                contact.FullName = updateContactRequest.FullName;
                contact.email = updateContactRequest.email;
                contact.Phone = updateContactRequest.Phone;
                contact.Address = updateContactRequest.Address;
                await dbContext.SaveChangesAsync();

                return Ok(contact);
            }
            
            
            return NotFound();
            
        }
        

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if(contact != null)
            {
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

    }
}
