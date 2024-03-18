using AdvancedRestApi.Models;

namespace AdvancedRestApi.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task AddUser(User user);
        Task UpdateUser(Guid id, User user);
        Task DeleteUser(Guid id);
    }
}
