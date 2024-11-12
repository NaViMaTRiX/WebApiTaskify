namespace WebApiTaskify.Interface;

using Models;

public interface IOrgLimitRepository
{
    Task<List<OrgLimit>> GetAllAsync(CancellationToken token);
    Task<OrgLimit?> GetByIdAsync(Guid id, CancellationToken token);
    Task<OrgLimit?> CreateAsync(OrgLimit listModel, CancellationToken token); 
    Task<OrgLimit?> UpdateAsync(Guid id, OrgLimit listModel, CancellationToken token);
    Task<OrgLimit?> DeleteAsync(Guid id, CancellationToken token);
    Task<bool> ExistAsync(Guid id, CancellationToken token);
}