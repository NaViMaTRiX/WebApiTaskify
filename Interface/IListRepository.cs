namespace WebApiTaskify.Interface;

using Models;

public interface IListRepository
{
    Task<List<Lists>> GetAllAsync();
    Task<Lists?> GetByIdAsync(Guid id);
    Task<Lists?> CreateAsync(Lists listModel); // TODO: Второго параметра нет? Почему?
    Task<Lists?> UpdateAsync(Guid id, Lists listModel);
    Task<Lists?> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}