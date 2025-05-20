namespace SalesWebMvc.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Seller> Sellers { get; set; } = [];

    public Department()
    {
    }

    public Department(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void AddSeler(Seller seller) => Sellers.Add(seller);

    public double TotalSales(DateTime inital, DateTime final) => Sellers.Sum(seller => seller.TotalSales(inital, final));
}
