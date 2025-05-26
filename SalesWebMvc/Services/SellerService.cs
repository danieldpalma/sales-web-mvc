﻿using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services;

public class SellerService
{
    private readonly SalesWebMvcContext _context;

    public SellerService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public List<Seller> FindAll() => _context.Sellers.ToList();

    public void Insert(Seller obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }
}
