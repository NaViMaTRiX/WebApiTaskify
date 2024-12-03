﻿namespace WebApiTaskify.Interface;

using Models;

public interface IBoardRepository
{
    Task<List<Boards>> GetAllAsync(CancellationToken token);
    Task<Boards?> GetByIdAsync(Guid id, CancellationToken token);
    Task<Boards?> GetAllByOrgIdAsync(string orgId, CancellationToken token);
    Task<Boards?> CreateAsync(string orgId, Boards boardModel, CancellationToken token); // OrgId и должен быть string
    Task<Boards?> UpdateAsync(Guid id, Boards boardModel, CancellationToken token);
    Task<Boards?> DeleteAsync(Guid id, CancellationToken token);
    Task<bool> ExistAsync(Guid id, CancellationToken token);
}