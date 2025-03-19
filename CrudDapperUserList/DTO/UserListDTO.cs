namespace CrudDapperUserList.DTO
{
    public class UserListDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public bool Situation { get; set; } // 1 - Active ; 0 - Inactive
    }
}