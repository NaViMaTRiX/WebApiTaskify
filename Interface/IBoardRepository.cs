namespace WebApiTaskify.Interface;

using Models;

public interface IBoardRepository
{
    Task<List<Board>> GetAllAsync();
    Task<Board?> GetByIdAsync(Guid id);
    Task<Board?> CreateAsync(string orgId, Board boardModel);
    Task<Board?> UpdateAsync(Guid id, Board boardModel);
    Task<Board?> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}