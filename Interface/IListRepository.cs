namespace WebApiTaskify.Interface;

using Models;

public interface IListRepository
{
    Task<List<List>> GetAllAsync();
    Task<List?> GetByIdAsync(Guid id);
    Task<List?> CreateAsync(List listModel); // TODO: Второго параметра нет? Почему?
    Task<List?> UpdateAsync(Guid id, List listModel);
    Task<List?> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}