﻿namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class CardRepository(AppDbContext context) : ICardRepository
{
    public async Task<List<Cards>> GetAllAsync(CancellationToken token)
    {
        return await context.Card.ToListAsync(token);
    }

    public async Task<Cards?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await context.Card.SingleOrDefaultAsync(x => x.Id == id, token);
    }

    public async Task<Cards?> CreateAsync(Cards cardModel, CancellationToken token)
    {
        await context.Card.AddAsync(cardModel, token);
        await context.SaveChangesAsync(token);
        return cardModel;
    }

    public async Task<Cards?> UpdateAsync(Guid id, Cards cardModel, CancellationToken token)
    {
        var checkCard = await GetByIdAsync(id, token);
        if(checkCard is null)
            return null;
        
        checkCard.Title = cardModel.Title;
        checkCard.Description = cardModel.Description;
        checkCard.Order = cardModel.Order;
        checkCard.Timer = cardModel.Timer;
        checkCard.TimeStart = cardModel.TimeStart;
        checkCard.TimeEnd = cardModel.TimeEnd;
        checkCard.Ready = cardModel.Ready;
        checkCard.LastModifyTime = cardModel.LastModifyTime;
        
        await context.SaveChangesAsync(token);
        return checkCard;
    }

    public async Task<Cards?> DeleteAsync(Guid id, CancellationToken token)
    {
        var checkCard = await GetByIdAsync(id, token);
        if(checkCard is null)
            return null;
        context.Card.Remove(checkCard);
        await context.SaveChangesAsync(token);
        return checkCard;
    }

    public  Task<bool> ExistAsync(Guid id, CancellationToken token)
    {
        return context.Card.AnyAsync(x=>x.Id == id, token);
    }
}