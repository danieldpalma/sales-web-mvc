using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services;

public class SellerService
{
    private readonly SalesWebMvcContext _context;

    public SellerService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public async Task<List<Seller>> FindAllAsync() => await _context.Sellers.ToListAsync();

    public async Task<Seller> FindByIdAsync(int id)
    {
        return await _context.Sellers
            .Include(x => x.Department)
            .FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException("Id not found.");
    }

    public async Task InsertAsync(Seller obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var obj = _context.Sellers.Find(id) ?? throw new NotFoundException("Id not found.");
        _context.Sellers.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Seller seller)
    {
        bool hasAny = await _context.Sellers.AnyAsync(x => x.Id == seller.Id);
        if (!hasAny)
        {
            throw new NotFoundException("Id not found.");
        }

        try
        {
            _context.Update(seller);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new DbConcurrencyException(ex.Message);
        }
    }
}
