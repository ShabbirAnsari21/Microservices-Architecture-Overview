using User_Service.Entity;

namespace User_Service.Infra
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task AddUser(User user);
        void DeleteUser(int id);
        Task<List<User>> GetAllUser();
    }
}
