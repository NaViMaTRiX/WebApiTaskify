namespace WebApiTaskify.Interface;

using Models;

public interface IListRepository
{
    Task<List<List>> GetAllAsync();
    Task<List?> GetByIdAsync(string id);
    Task<List?> CreateAsync(List listModel); // TODO: Второго параметра нет? Почему?
    Task<List?> UpdateAsync(string id, List listModel);
    Task<List?> DeleteAsync(string id);
    Task<bool> ExistAsync(string id);
}