namespace WebApiTaskify.Interface;

using Models;

public interface IListRepository
{
    Task<List<List>> GetAllAsync(CancellationToken token);
    Task<List?> GetByIdAsync(Guid id, CancellationToken token);
    Task<List?> CreateAsync(List listModel, CancellationToken token); // TODO: Второго параметра нет? Почему?
    Task<List?> UpdateAsync(Guid id, List listModel, CancellationToken token);
    Task<List?> DeleteAsync(Guid id, CancellationToken token);
    Task<bool> ExistAsync(Guid id, CancellationToken token);
}