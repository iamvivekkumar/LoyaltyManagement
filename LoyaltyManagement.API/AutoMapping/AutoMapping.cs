using AutoMapper;
using LoyaltyManagement.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyManagement.API.AutoMapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //DTO To business Models
            CreateMap<UserLoginDto, BLL.Models.UserModel>();
            CreateMap<UserRegistrationDto, BLL.Models.UserModel>();



            //Business Models To Entities
            CreateMap<BLL.Models.UserModel, DAL.Entities.User>();


            //Entities to Business Models
            CreateMap<DAL.Entities.User,BLL.Models.UserModel>();
        }
    }
}
