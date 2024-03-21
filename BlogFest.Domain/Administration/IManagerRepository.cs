namespace BlogFest.Domain.Administration
{
    public interface IManagerRepository
    {
        Task<Manager> GetManagerByIdAsync(Guid Id);
        Task<UserSettings> GetUserSettingsByIdAsync(Guid Id);
        Task Update(Manager model);
    }
}
