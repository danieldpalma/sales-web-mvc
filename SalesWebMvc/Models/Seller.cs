using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models;

public class Seller
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} required.")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1} characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} required.")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Enter a valid email.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} required.")]
    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "{0} required.")]
    [Display(Name = "Base Salary")]
    [DisplayFormat(DataFormatString = "{0:F2}")]
    [Range(100, 50000, ErrorMessage = "{0} must be from {1} to {2}")]
    public double BaseSalary { get; set; }

    public Department? Department { get; set; }

    [Display(Name = "Department")]
    public int DepartmentId { get; set; }

    public ICollection<SalesRecord> Sales { get; set; } = [];

    public Seller()
    {
    }

    public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        Department = department;
    }

    public Seller(string name, string email, DateTime birthDate, double baseSalary, Department department)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        Department = department;
    }

    public void AddSales(SalesRecord sr) => Sales.Add(sr);

    public void RemoveSales(SalesRecord sr) => Sales.Remove(sr);

    public double TotalSales(DateTime inital, DateTime final) => Sales.Where(sr => sr.Date >= inital && sr.Date <= final).Sum(sr => sr.Amount);
}
