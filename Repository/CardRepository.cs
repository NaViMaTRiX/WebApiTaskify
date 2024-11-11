namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class CardRepository : ICardRepository
{
    private readonly AppDbContext _context;

    public CardRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Card>> GetAllAsync()
    {
        return await _context.Card.ToListAsync();
    }

    public async Task<Card?> GetByIdAsync(Guid id)
    {
        return await _context.Card.SingleOrDefaultAsync(x => x.id == id);
    }

    public async Task<Card?> CreateAsync(Card cardModel)
    {
        await _context.Card.AddAsync(cardModel);
        await _context.SaveChangesAsync();
        return cardModel;
    }

    public async Task<Card?> UpdateAsync(Guid id, Card cardModel)
    {
        var checkCard = await GetByIdAsync(id);
        if(checkCard is null)
            return null;
        
        checkCard.title = cardModel.title;
        checkCard.description = cardModel.description;
        checkCard.order = cardModel.order;
        checkCard.timer = cardModel.timer;
        checkCard.timeStart = cardModel.timeStart;
        checkCard.timeEnd = cardModel.timeEnd;
        checkCard.ready = cardModel.ready;
        checkCard.updatedAt = cardModel.updatedAt;
        await _context.SaveChangesAsync();
        return checkCard;
    }

    public async Task<Card?> DeleteAsync(Guid id)
    {
        var checkCard = await GetByIdAsync(id);
        if(checkCard is null)
            return null;
        _context.Card.Remove(checkCard);
        await _context.SaveChangesAsync();
        return checkCard;
    }

    public  Task<bool> ExistAsync(Guid id)
    {
        return _context.Card.AnyAsync(x=>x.id == id);
    }
}