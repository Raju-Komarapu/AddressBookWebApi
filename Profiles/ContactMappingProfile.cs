using AutoMapper;

namespace AddressBookWebApi.Profiles
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<CoreModel.Contact.Contact, DataModel.Contact.Contact>().ReverseMap();
        }
    }
}
