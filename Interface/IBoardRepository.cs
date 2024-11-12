namespace WebApiTaskify.Interface;

using Models;

public interface IBoardRepository
{
    Task<List<Board>> GetAllAsync(CancellationToken token);
    Task<Board?> GetByIdAsync(Guid id, CancellationToken token);
    Task<Board?> GetAllByOrgIdAsync(string orgId, CancellationToken token);
    Task<Board?> CreateAsync(string orgId, Board boardModel, CancellationToken token); // orgId и должен быть string
    Task<Board?> UpdateAsync(Guid id, Board boardModel, CancellationToken token);
    Task<Board?> DeleteAsync(Guid id, CancellationToken token);
    Task<bool> ExistAsync(Guid id, CancellationToken token);
}