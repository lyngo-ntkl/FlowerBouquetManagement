using AutoMapper;
using BusinessObjects.Models;
using DTOs;

namespace FlowerBouquetManagementSystemWebApp.Helper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<FlowerBouquet, FlowerBouquetDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        }
    }
}
