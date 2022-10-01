using AutoMapper;
using CardStorageService.Models.Requests;
using CardStorageService.Models;

namespace CardStorageService.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Card, CardDto>();
            CreateMap<CreateCardRequest, Card>();
            CreateMap<Client, ClientDto>();
            CreateMap<CreateClientRequest, Client>();
        }

    }
}
