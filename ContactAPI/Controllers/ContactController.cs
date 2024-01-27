using ContactAPI.Data;
using ContactAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

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
		private readonly DataContext _context;
		public ContactController(DataContext context) 
		{
			_context = context;
		}

		[HttpGet]
		public async Task <ActionResult<IEnumerable<Contact>>> GetContacts()
		{
			return await _context.Contacts.ToListAsync();
		}

		[HttpGet("{id:int}",Name ="GetContact")]
		public async Task<ActionResult<Contact>> GetContactById(int id)
		{
			var contact = await _context.Contacts.FindAsync(id);
			if (contact == null)
			{
				return NotFound(new { Message = "Contact not found..." });
			}
			return Ok(contact);
		}


		[HttpPost]
		public async Task<ActionResult<Contact>> CreateContact([FromBody] Contact newContact)
		{
			//if (newContact == null)
			//{
			//	return BadRequest("Invalid data");
			//}
			//if (newContact.Id > 0)
			//{
			//	return StatusCode(StatusCodes.Status500InternalServerError);
			//}
			//newContact.Id = _context.Contacts.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
			_context.Contacts.Add(newContact);
			await _context.SaveChangesAsync();
			return CreatedAtRoute("GetContact", new {id=newContact.Id},newContact);

		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<Contact>> UpdateContact(int id, [FromBody] Contact updatedContact)
		{
			var contact = await _context.Contacts.FindAsync(id);

			if (contact == null)
			{
				return NotFound();
			}
			contact.Id = updatedContact.Id;
			contact.Phone = updatedContact.Phone;
			contact.FirstName = updatedContact.FirstName;
			contact.LastName = updatedContact.LastName;
			contact.City = updatedContact.City;
			await _context.SaveChangesAsync();
			return Ok(contact);
		}

		[HttpDelete]
		public async Task<ActionResult<IEnumerable<Contact>>> DeleteContact(int id)
		{
			var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
			if (contact == null)
			{
				return NotFound();
			}
			_context.Contacts.Remove(contact);
			await _context.SaveChangesAsync();
			return Ok();
		}

	}

}