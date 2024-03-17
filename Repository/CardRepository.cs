namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class CardRepository : ICardRepository
{
    private readonly AppDBContext _context;

    public CardRepository(AppDBContext context)
    {
        _context = context;
    }
    public async Task<List<Cards>> GetAllAsync()
    {
        return await _context.Cards.ToListAsync();
    }

    public async Task<Cards?> GetByIdAsync(Guid id)
    {
        return await _context.Cards.FindAsync(id);
    }

    public async Task<Cards?> CreateAsync(Cards cardModel)
    {
        await _context.Cards.AddAsync(cardModel);
        await _context.SaveChangesAsync();
        return cardModel;
    }

    public async Task<Cards?> UpdateAsync(Guid id, Cards cardModel)
    {
        var checkCard = await _context.Cards.FindAsync(id);
        if(checkCard is null)
            return null;
        
        checkCard.Title = cardModel.Title;
        checkCard.Description = cardModel.Description;
        checkCard.Order = cardModel.Order;
        checkCard.isChecked = cardModel.isChecked;
        checkCard.UpdatedAt = cardModel.UpdatedAt;
        await _context.SaveChangesAsync();
        return cardModel;
    }

    public async Task<Cards?> DeleteAsync(Guid id)
    {
        var checkCard = await _context.Cards.FindAsync(id);
        if(checkCard is null)
            return null;
        _context.Cards.Remove(checkCard);
        await _context.SaveChangesAsync();
        return checkCard;
    }

    public  Task<bool> ExistAsync(Guid id)
    {
        return _context.Cards.AnyAsync(x=>x.Id == id);
    }
}