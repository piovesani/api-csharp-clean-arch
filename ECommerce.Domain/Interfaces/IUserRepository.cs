using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces
{
    public interface IUserRepository
    {
        //public List<User> GetUsersAsync();

        //public User GetByIdAsync(int id);

        //public void InsertUserAsync(User user);

        //public void UpdateUserAsync(User user);

        //public void DeleteUserAsync(int id);

        Task<List<User>> GetUsersAsync();
        Task<User?> GetByIdAsync(int id);
        Task InsertUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
