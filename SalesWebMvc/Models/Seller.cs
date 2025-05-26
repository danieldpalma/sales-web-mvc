﻿namespace SalesWebMvc.Models;

public class Seller
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public double BaseSalary { get; set; }
    public Department Department { get; set; }
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
