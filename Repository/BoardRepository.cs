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

    public async Task<List<Board>> GetAllAsync()
    {
        return await _context.Board.ToListAsync();
    }

    public async Task<Board?> GetByIdAsync(string id)
    {
        return await _context.Board.SingleOrDefaultAsync(x => x.id == id);
    }

    public async Task<Board?> CreateAsync(string orgId, Board boardModel)
    {
        var objOrgId = await _context.Board.SingleOrDefaultAsync(x => x.orgId == orgId);
        if (objOrgId is null)
            return null;
        
        await _context.Board.AddAsync(boardModel);
        await _context.SaveChangesAsync();
        return boardModel;
    }

    public async Task<Board?> UpdateAsync(string id, Board boardModel)
    {
        var board = await GetByIdAsync(id);
        
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

    public async Task<Board?> DeleteAsync(string id)
    {
        var board = await GetByIdAsync(id);
        
        if (board is null)
            return null;
        
        _context.Board.Remove(board);
        await _context.SaveChangesAsync();
        return board;
    }

    public Task<bool> ExistAsync(string id)
    {
        return _context.Board.AnyAsync(x => x.id == id);
    }
}