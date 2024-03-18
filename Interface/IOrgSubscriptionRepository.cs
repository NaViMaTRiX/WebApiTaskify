namespace WebApiTaskify.Interface;

using Models;

public interface IOrgSubscriptionRepository
{
    Task<List<OrgSubscriptions>> GetAllAsync();
    Task<OrgSubscriptions?> GetByIdAsync(Guid id);
    Task<OrgSubscriptions?> CreateAsync(OrgSubscriptions listModel); 
    Task<OrgSubscriptions?> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}