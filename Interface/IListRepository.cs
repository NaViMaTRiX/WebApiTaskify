﻿namespace WebApiTaskify.Interface;

using Models;

public interface IListRepository
{
    Task<List<Lists>> GetAllAsync(CancellationToken token);
    Task<Lists?> GetByIdAsync(Guid id, CancellationToken token);
    Task<Lists?> CreateAsync(Lists listModel, CancellationToken token); // TODO: Второго параметра нет? Почему?
    Task<Lists?> UpdateAsync(Guid id, Lists listModel, CancellationToken token);
    Task<Lists?> DeleteAsync(Guid id, CancellationToken token);
    Task<bool> ExistAsync(Guid id, CancellationToken token);
}