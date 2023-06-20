using AddressBookWebApi.CoreModel.Contact;
using AddressBookWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookWebApi.Controllers
{
    [Route("api/contacts")]
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        [HttpGet]
        public IEnumerable<Contact> GetContacts()
        {
            return this._contactService.GetContacts();
        }

        [HttpGet("{id}")]
        public Contact GetContact(Guid id)
        {
            return this._contactService.GetContact(id);
        }

        [HttpPost]
        public Guid Add(Contact contact)
        {
            return this._contactService.AddContact(contact);
        }

        [HttpPut]
        public void Update(Contact contact)
        {
            this._contactService.UpdateContact(contact);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            this._contactService.DeleteContact(id);
        }

        [HttpPatch]
        public void ToggleFavorite(Guid id)
        {
            this._contactService.ToggleFavorite(id);
        }
    }
}
