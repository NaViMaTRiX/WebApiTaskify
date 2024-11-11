namespace WebApiTaskify.Interface;

using Models;

public interface IOrgSubscriptionRepository
{
    Task<List<OrgSubscription>> GetAllAsync();
    Task<OrgSubscription?> GetByIdAsync(Guid id);
    Task<OrgSubscription?> CreateAsync(OrgSubscription listModel); 
    Task<OrgSubscription?> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}