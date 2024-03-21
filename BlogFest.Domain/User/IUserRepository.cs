namespace BlogFest.Domain.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers(List<Guid> ids);
        Task<User> GetUserByIdAsync(Guid id);
        Task Add(User user);
        Task Update(User user);
        Task Remove(Guid id);
    }
}
