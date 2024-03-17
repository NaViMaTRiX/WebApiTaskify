namespace WebApiTaskify.Interface;

using Models;

public interface IOrgLimitRepository
{
    Task<List<OrgLimits>> GetAllAsync();
    Task<OrgLimits?> GetByIdAsync(Guid id);
    Task<OrgLimits?> CreateAsync(OrgLimits listModel); 
    Task<OrgLimits?> UpdateAsync(Guid id, OrgLimits listModel);
    Task<OrgLimits?> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}