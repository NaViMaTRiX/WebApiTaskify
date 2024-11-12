namespace WebApiTaskify.Interface;

using Models;

public interface IOrgSubscriptionRepository
{
    Task<List<OrgSubscription>> GetAllAsync(CancellationToken token);
    Task<OrgSubscription?> GetByIdAsync(Guid id, CancellationToken token);
    Task<OrgSubscription?> CreateAsync(OrgSubscription listModel, CancellationToken token); 
    Task<OrgSubscription?> DeleteAsync(Guid id, CancellationToken token);
    Task<bool> ExistAsync(Guid id, CancellationToken token);
}