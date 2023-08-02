using AutoMapper;
using BusinessObjects.Models;
using DTOs;

namespace FlowerBouquetManagementSystemWebApp.Helper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<FlowerBouquet, FlowerBouquetDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDetail, OrderDetailDTO>();
        }
    }
}
