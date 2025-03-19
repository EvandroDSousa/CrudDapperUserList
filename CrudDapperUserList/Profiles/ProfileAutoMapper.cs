using AutoMapper;
using CrudDapperUserList.DTO;
using CrudDapperUserList.Models;

namespace CrudDapperUserList.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<User, UserListDTO>();
        }
    }
}