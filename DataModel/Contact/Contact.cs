using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookWebApi.DataModel.Contact
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Landline { get; set; }

        public string Website { get; set; }

        public string Address { get; set; }

        public bool IsFavorite { get; set; }

    }
}
