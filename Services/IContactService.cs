using AddressBookWebApi.CoreModel.Contact;

namespace AddressBookWebApi.Services
{
    public interface IContactService
    {
        Guid AddContact(Contact newContact);

        Contact GetContact(Guid id);

        IEnumerable<Contact> GetContacts();

        void UpdateContact(Contact contact);

        void DeleteContact(Guid id);

        void ToggleFavorite(Guid id);
    }
}
