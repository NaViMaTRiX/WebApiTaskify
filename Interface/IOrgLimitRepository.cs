namespace WebApiTaskify.Interface;

using Models;

public interface IOrgLimitRepository
{
    Task<List<OrgLimit>> GetAllAsync();
    Task<OrgLimit?> GetByIdAsync(string id);
    Task<OrgLimit?> CreateAsync(OrgLimit listModel); 
    Task<OrgLimit?> UpdateAsync(string id, OrgLimit listModel);
    Task<OrgLimit?> DeleteAsync(string id);
    Task<bool> ExistAsync(string id);
}