using AddressBookWebApi.CoreModel.Contact;
using AddressBookWebApi.DbContext;
using AutoMapper;

namespace AddressBookWebApi.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ContactService(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public Guid AddContact(Contact newContact)
        {
            var contact = this._mapper.Map<DataModel.Contact.Contact>(newContact);
            string sqlQuery = "INSERT INTO Contacts (Name,Email,Mobile,Landline,Website,Address) OUTPUT INSERTED.Id VALUES (@name,@email,@mobile,@landline,@website,@address)";
            return this._db.ExecuteScalar<Guid>(sqlQuery, newContact);
        }

        public Contact GetContact(Guid id)
        {
            var contact = this._db.Get<DataModel.Contact.Contact>(id);
            return this._mapper.Map<Contact>(contact);
        }

        public IEnumerable<Contact> GetContacts()
        {
            var contact = this._db.GetAll<DataModel.Contact.Contact>();
            return this._mapper.Map<IEnumerable<Contact>>(contact);
        }

        public void UpdateContact(Contact contact)
        {
            this._db.Update<DataModel.Contact.Contact>(this._mapper.Map<DataModel.Contact.Contact>(contact));
        }

        public void DeleteContact(Guid id)
        {
            string sqlQuery = "DELETE FROM Contacts WHERE Id = @id";
            this._db.Execute(sqlQuery, new { id });
        }

        public void ToggleFavorite(Guid id)
        {
            var existingContact = this.GetContact(id);
            existingContact.IsFavorite = !existingContact.IsFavorite;
            this.UpdateContact(existingContact);
        }
    }
}
