using CrudDapperUserList.DTO;
using CrudDapperUserList.Models;

namespace CrudDapperUserList.Services
{
    public interface IUserInterface
    {
        Task<ResponseModel<List<UserListDTO>>> GetUserList();
        Task<ResponseModel<UserListDTO>> GetUserById(int userId);
        Task<ResponseModel<List<UserListDTO>>> CreateUser(CreateUserDTO createUserDTO);
        Task<ResponseModel<List<UserListDTO>>> AlterUser(AlterUserDTO alterUserDTO);
        Task<ResponseModel<List<UserListDTO>>> RemoveUser(int userId);

    }
}