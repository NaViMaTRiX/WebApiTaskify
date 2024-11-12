namespace WebApiTaskify.Interface;

using Models;

public interface ICardRepository
{
    Task<List<Card>> GetAllAsync(CancellationToken token);
    Task<Card?> GetByIdAsync(Guid id, CancellationToken token);
    Task<Card?> CreateAsync(Card cardModel, CancellationToken token);
    Task<Card?> UpdateAsync(Guid id, Card cardModel, CancellationToken token);
    Task<Card?> DeleteAsync(Guid id, CancellationToken token);
    Task<bool> ExistAsync(Guid id, CancellationToken token);
}