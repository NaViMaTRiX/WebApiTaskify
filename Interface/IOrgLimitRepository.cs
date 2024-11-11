namespace WebApiTaskify.Interface;

using Models;

public interface IOrgLimitRepository
{
    Task<List<OrgLimit>> GetAllAsync();
    Task<OrgLimit?> GetByIdAsync(Guid id);
    Task<OrgLimit?> CreateAsync(OrgLimit listModel); 
    Task<OrgLimit?> UpdateAsync(Guid id, OrgLimit listModel);
    Task<OrgLimit?> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}