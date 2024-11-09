namespace WebApiTaskify.Interface;

using Models;

public interface ICardRepository
{
    Task<List<Card>> GetAllAsync();
    Task<Card?> GetByIdAsync(string id);
    Task<Card?> CreateAsync(Card cardModel);
    Task<Card?> UpdateAsync(string id, Card cardModel);
    Task<Card?> DeleteAsync(string id);
    Task<bool> ExistAsync(string id);
}