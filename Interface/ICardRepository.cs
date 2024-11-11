namespace WebApiTaskify.Interface;

using Models;

public interface ICardRepository
{
    Task<List<Card>> GetAllAsync();
    Task<Card?> GetByIdAsync(Guid id);
    Task<Card?> CreateAsync(Card cardModel);
    Task<Card?> UpdateAsync(Guid id, Card cardModel);
    Task<Card?> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}