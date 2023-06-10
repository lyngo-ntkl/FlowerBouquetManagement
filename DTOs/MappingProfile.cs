using AutoMapper;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<FlowerBouquet, FlowerBouquetDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDetail, OrderDetailDTO>();
        }
    }
}
