namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class BoardRepository : IBoardRepository
{
    private readonly AppDBContext _context;

    public BoardRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<Boards>> GetAllAsync()
    {
        return await _context.Boards.ToListAsync();
    }

    public async Task<Boards?> GetByIdAsync(Guid id)
    {
        return await _context.Boards.FindAsync(id);
    }

    public async Task<Boards?> CreateAsync(Boards boardsModel)
    {
        await _context.Boards.AddAsync(boardsModel);
        await _context.SaveChangesAsync();
        return boardsModel;
    }

    public async Task<Boards?> UpdateAsync(Guid id, Boards boardsModel)
    {
        var board = await _context.Boards.FindAsync(id);
        
        if (board is null)
            return null;
        
        board.OrgId = boardsModel.OrgId;
        board.Title = boardsModel.Title;
        board.ImageId = boardsModel.ImageId;
        board.ImageThumbUrl = boardsModel.ImageThumbUrl;
        board.ImageFullUrl = boardsModel.ImageFullUrl;
        board.ImageUserName = boardsModel.ImageUserName;
        board.ImageLinkHtml = boardsModel.ImageLinkHtml;
        board.UpdatedAt = boardsModel.UpdatedAt;
        
        await _context.SaveChangesAsync();
        return board;
    }

    public async Task<Boards?> DeleteAsync(Guid id)
    {
        var board = await _context.Boards.FindAsync(id);
        
        if (board is null)
            return null;
        
        _context.Boards.Remove(board);
        await _context.SaveChangesAsync();
        return board;
    }

    public Task<bool> ExistAsync(Guid id)
    {
        return _context.Boards.AnyAsync(x => x.Id == id);
    }
}