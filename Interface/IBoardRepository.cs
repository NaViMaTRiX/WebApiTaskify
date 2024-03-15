namespace WebApiTaskify.Interface;

using Models;

public interface IBoardRepository
{
    Task<List<Boards>> GetAllAsync();
    Task<Boards?> GetByIdAsync(Guid id);
    Task<Boards?> CreateAsync(Boards boardsModel);
    Task<Boards?> UpdateAsync(Guid id, Boards boardsModel);
    Task<Boards?> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}