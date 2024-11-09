namespace WebApiTaskify.Interface;

using Models;

public interface IOrgSubscriptionRepository
{
    Task<List<OrgSubscription>> GetAllAsync();
    Task<OrgSubscription?> GetByIdAsync(string id);
    Task<OrgSubscription?> CreateAsync(OrgSubscription listModel); 
    Task<OrgSubscription?> DeleteAsync(string id);
    Task<bool> ExistAsync(string id);
}