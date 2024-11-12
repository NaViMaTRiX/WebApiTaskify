namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class BoardRepository : IBoardRepository
{
    private readonly AppDbContext _context;

    public BoardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Board>> GetAllAsync(CancellationToken token)
    {
        return await _context.Board.Include(x => x.Lists).ToListAsync(token);;
    }

    public async Task<Board?> GetByIdAsync(Guid id, CancellationToken token)
    {
         var board =  await _context.Board
            .Include(x => x.Lists)
            .FirstOrDefaultAsync(x => x.id == id, token);
         return board;
    }

    public async Task<Board?> CreateAsync(string orgId, Board boardModel, CancellationToken token)
    {
        var objOrgId = await _context.Board.SingleOrDefaultAsync(x => x.orgId == orgId, token);
        if (objOrgId is null)
            return null;
        
        await _context.Board.AddAsync(boardModel, token);
        await _context.SaveChangesAsync(token);
        return boardModel;
    }

    public async Task<Board?> UpdateAsync(Guid id, Board boardModel, CancellationToken token)
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
        board.updatedAt = boardModel.updatedAt;
        
        await _context.SaveChangesAsync();
        return board;
    }

    public async Task<Board?> DeleteAsync(Guid id, CancellationToken token)
    {
        var board = await GetByIdAsync(id, token);
        
        if (board is null)
            return null;
        
        _context.Board.Remove(board);
        await _context.SaveChangesAsync(token);
        return board;
    }

    public Task<bool> ExistAsync(Guid id, CancellationToken token)
    {
        return _context.Board.AnyAsync(x => x.id == id, token);
    }
}