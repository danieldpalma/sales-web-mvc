using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services;

public class DepartmentService
{
    private readonly SalesWebMvcContext _context;

    public DepartmentService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> FindAllAsync() => await _context.Departments.OrderBy(department => department.Name).ToListAsync();
}
