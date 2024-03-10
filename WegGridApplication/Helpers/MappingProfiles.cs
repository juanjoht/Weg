using AutoMapper;
using System.Net;
using WegGridApplication.Models;
using WegGridCore.Models;

namespace WegGridApplication.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OrderModel, OrderResultModel>();
            CreateMap<OrderResultModel, OrderModel>();
        }
    }
}
