namespace WebApiTaskify.Interface;

using Models;

public interface IListRepository
{
    Task<List<Lists>> GetAllAsync();
    Task<Lists?> GetByIdAsync(string id);
    Task<Lists?> CreateAsync(Lists listModel);
    Task<Lists?> UpdateAsync(string id, Lists listModel);
    Task<Lists?> DeleteAsync(string id);
    Task<bool> ExistAsync(string id);
}