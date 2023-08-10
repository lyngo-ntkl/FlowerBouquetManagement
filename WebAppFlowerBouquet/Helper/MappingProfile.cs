using AutoMapper;
using BusinessObjects.Models;
using DTOs;

namespace WebAppFlowerBouquet.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() { 
            CreateMap<FlowerBouquetDTO, FlowerBouquet>().ReverseMap();
        }
    }
}
