using ContactAPI.Data;
using ContactAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ContactAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
    //    private List<Contact> contacts = new List<Contact>
    //{
    //    new Contact { Id = 1,FirstName="Pavan",LastName="Perumalla",City="SAP",Phone=9951658045,CreatedDate=DateTime.Now},
    //    new Contact { Id = 2,FirstName="Harini",LastName="Devathi",City="GNT",Phone=9381272144,CreatedDate=DateTime.Now}
    //};

        // while we creating separate folder for the list to store
        // the items it would be reflected (it will show) in the httpget
        // otherwise it won't reflect..
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            return Ok(ContactStore.contacts);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Contact> GetContactById(int id) 
        {
            var contact = ContactStore.contacts.FirstOrDefault(c => c.Id == id);
            if (contact==null )
            {
                return NotFound(new {Message = "Contact not found..."});
            }
            return Ok(contact);
        }


        [HttpPost]
        public ActionResult<IEnumerable<Contact>> CreateContact([FromBody]Contact newContact)
        {
            if (newContact == null)
            {
                return BadRequest("Invalid data");
            }
            if(newContact.Id > 0) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            newContact.Id = ContactStore.contacts.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
            ContactStore.contacts.Add(newContact);
            return Ok(newContact);

        }

        [HttpPut("{id:int}")]
        public ActionResult <IEnumerable<Contact>> UpdateContact(int id,[FromBody]Contact updatedContact) 
        {
            var contact = ContactStore.contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null) 
            {
                return NotFound();
            }
            contact.Id = updatedContact.Id;
            contact.Phone = updatedContact.Phone;
            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.City = updatedContact.City;
            return Ok(contact);
        }

        [HttpDelete]
        public ActionResult<IEnumerable<Contact>> DeleteContact(int id) 
        {
            var contact = ContactStore.contacts.FirstOrDefault(c => c.Id == id);
            if(contact == null)
            {
                return NotFound();
            }
            ContactStore.contacts.Remove(contact);
            return Ok();
        }

    }
}
