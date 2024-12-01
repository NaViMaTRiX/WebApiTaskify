namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class BoardRepository(AppDbContext context) : IBoardRepository
{
    public async Task<List<Boards>> GetAllAsync(CancellationToken token)
    {
        return await context.Board.Include(x => x.Lists).ToListAsync(token);;
    }

    public async Task<Boards?> GetByIdAsync(Guid id, CancellationToken token)
    {
         var board =  await context.Board
            .Include(x => x.Lists)
            .FirstOrDefaultAsync(x => x.id == id, token);
         return board;
    }

    public Task<Boards?> GetAllByOrgIdAsync(string orgId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<Boards?> CreateAsync(string orgId, Boards boardModel, CancellationToken token)
    {
        var objOrgId = await context.Board.SingleOrDefaultAsync(x => x.orgId == orgId, token);
        if (objOrgId is null)
            return null;
        
        await context.Board.AddAsync(boardModel, token);
        await context.SaveChangesAsync(token);
        return boardModel;
    }

    public async Task<Boards?> UpdateAsync(Guid id, Boards boardModel, CancellationToken token)
    {
        var board = await GetByIdAsync(id, token);
        
        if (board is null)
            return null;
        
        board.orgId = boardModel.orgId;
        board.title = boardModel.title;
        board.imageId = boardModel.imageId;
        board.imageThumbUrl = boardModel.imageThumbUrl;
        board.imageFullUrl = boardModel.imageFullUrl;
        board.imageUserName = boardModel.imageUserName;
        board.imageLinkHTML = boardModel.imageLinkHTML;
        board.lastModifyTime = boardModel.lastModifyTime;
        
        await context.SaveChangesAsync();
        return board;
    }

    public async Task<Boards?> DeleteAsync(Guid id, CancellationToken token)
    {
        var board = await GetByIdAsync(id, token);
        
        if (board is null)
            return null;
        
        context.Board.Remove(board);
        await context.SaveChangesAsync(token);
        return board;
    }

    public Task<bool> ExistAsync(Guid id, CancellationToken token)
    {
        return context.Board.AnyAsync(x => x.id == id, token);
    }
}