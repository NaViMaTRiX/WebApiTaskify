namespace WebApiTaskify.Interface;

using Models;

public interface IBoardRepository
{
    Task<List<Boards>> GetAllAsync();
    Task<Boards?> GetByIdAsync(string id);
    Task<Boards?> CreateAsync(Boards boardsModel);
    Task<Boards?> UpdateAsync(string id, Boards boardsModel);
    Task<Boards?> DeleteAsync(string id);
    Task<bool> ExistAsync(string id);
}