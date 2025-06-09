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

    public List<Seller> FindAll() => _context.Sellers.ToList();

    public Seller FindById(int id) => _context.Sellers.Include(x => x.Department).FirstOrDefault(x => x.Id == id);

    public void Insert(Seller obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Remove(int id)
    {
        var obj = _context.Sellers.Find(id);
        _context.Sellers.Remove(obj);
        _context.SaveChanges();
    }

    public void Update(Seller seller)
    {
        if (!_context.Sellers.Any(x => x.Id == seller.Id))
        {
            throw new NotFoundException("Id not found.");
        }

        try
        {
            _context.Update(seller);
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new DbConcurrencyException(ex.Message);
        }
    }
}
