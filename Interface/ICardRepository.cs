namespace WebApiTaskify.Interface;

using Models;

public interface ICardRepository
{
    Task<List<Cards>> GetAllAsync();
    Task<Cards?> GetByIdAsync(Guid id);
    Task<Cards?> CreateAsync(Cards cardModel);
    Task<Cards?> UpdateAsync(Guid id, Cards cardModel);
    Task<Cards?> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}