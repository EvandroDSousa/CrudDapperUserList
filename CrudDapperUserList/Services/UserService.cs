using AutoMapper;
using CrudDapperUserList.DTO;
using CrudDapperUserList.Models;
using CrudDapperUserList.Resources;
using Dapper;
using MySql.Data.MySqlClient;

namespace CrudDapperUserList.Services
{
    public class UserService : IUserInterface
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<UserListDTO>>> CreateUser(CreateUserDTO createUserDTO)
        {
            ResponseModel<List<UserListDTO>> response = new();

            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var usersDatabase = await connection.ExecuteAsync("insert into Users (FullName, Email, Position, TaxNumber, Salary, Situation, `Password`) " +
                                                                      "values (@FullName, @Email, @Position, @TaxNumber, @Salary, @Situation, @Password)", createUserDTO);
                    if(usersDatabase == 0)
                    {
                        response.Messages = string.Format(ResponseMessages.INF05);
                        response.Status = false;
                        return response;
                    }

                    var users = await ListUsers(connection);

                    var mapUser = _mapper.Map<List<UserListDTO>>(users);

                    response.Data = mapUser;
                    response.Messages = string.Format(ResponseMessages.INF04);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseModel<UserListDTO>> GetUserById(int userId)
        {
            ResponseModel<UserListDTO> response = new ();

            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var usersDatabase = await connection.QueryFirstOrDefaultAsync<User>("select * from Users where UserId = @Id", new {Id = userId});

                    if (usersDatabase == null)
                    {
                        response.Messages = string.Format(ResponseMessages.INF01);
                        response.Status = false;
                        return response;
                    }

                    var mapUser = _mapper.Map<UserListDTO>(usersDatabase);

                    response.Data = mapUser;
                    response.Messages = string.Format(ResponseMessages.INF03);
                }

                return response;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<ResponseModel<List<UserListDTO>>> GetUserList()
        {
            ResponseModel<List<UserListDTO>> response = new();

            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var usersDatabase = await connection.QueryAsync<User>("select * from Users");

                    if (usersDatabase.Count() == 0)
                    {
                        response.Messages = string.Format(ResponseMessages.INF01);
                        response.Status = false;
                        return response;
                    }

                    var mapUser = _mapper.Map<List<UserListDTO>>(usersDatabase);

                    response.Data = mapUser;
                    response.Messages = string.Format(ResponseMessages.INF02);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseModel<List<UserListDTO>>> AlterUser(AlterUserDTO alterUserDTO)
        {
            ResponseModel<List<UserListDTO>> response = new();

            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var usersDatabase = await connection.ExecuteAsync("update Users set FullName = @FullName, " +
                                                                                        "Email = @Email, " +
                                                                                        "Position = @Position, " +
                                                                                        "TaxNumber = @TaxNumber, " +
                                                                                        "Salary = @Salary, " +
                                                                                        "Situation = @Situation where UserId = @UserId ", alterUserDTO);

                    if(usersDatabase == 0)
                    {
                        response.Messages = string.Format(ResponseMessages.INF06);
                        response.Status = false; 
                        return response;
                    }

                    var users = await ListUsers(connection);

                    var mapUser = _mapper.Map<List<UserListDTO>>(users);

                    response.Data = mapUser;
                    response.Messages = string.Format(ResponseMessages.INF07);
                }

                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseModel<List<UserListDTO>>> RemoveUser(int userId)
        {
            ResponseModel<List<UserListDTO>> response = new();

            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var usersDatabase = await connection.ExecuteAsync("delete from Users where UserId = @Id", new { Id = userId });

                    if (usersDatabase == 0)
                    {
                        response.Messages = string.Format(ResponseMessages.INF08);
                        response.Status = false;
                        return response;
                    }

                    var users = await ListUsers(connection);

                    var mapUser = _mapper.Map<List<UserListDTO>>(users);

                    response.Data = mapUser;
                    response.Messages = string.Format(ResponseMessages.INF09);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task<IEnumerable<User>> ListUsers(MySqlConnection connection)
        {
            return await connection.QueryAsync<User>("select * from Users");
        }
    }
}