using AutoMapper;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    //this is the configuration class for mapping,which is required by startup class when addding service
    public class DutchMappingProfile :Profile
    {
        public DutchMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(destination => destination.OrderId, ex => ex.MapFrom(src => src.Id))
                .ForMember(destination => destination.OrederNumber, ex => ex.MapFrom(src => src.OrderNumber))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
        }
    }
}
