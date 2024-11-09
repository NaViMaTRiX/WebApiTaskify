namespace WebApiTaskify.Interface;

using Models;

public interface IBoardRepository
{
    Task<List<Board>> GetAllAsync();
    Task<Board?> GetByIdAsync(string id);
    Task<Board?> CreateAsync(string orgId, Board boardModel);
    Task<Board?> UpdateAsync(string id, Board boardModel);
    Task<Board?> DeleteAsync(string id);
    Task<bool> ExistAsync(string id);
}