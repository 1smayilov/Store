using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Product:Entity<int>
{
    public string Title { get; set; }
    public double Price { get; set; }
    public string CoverImage { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Adress { get; set; }
    public string Description { get; set; }

    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public int EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; }

    public Product()
    {
        ProductDetails = new HashSet<ProductDetail>();
    }


    public Product(int id, string title, double price, string coverImage, string city, string district, string adress, string description) : this()
    {
        Id = id; 
        Title = title; 
        Price = price; 
        CoverImage = coverImage; 
        City = city; 
        District = district; 
        Adress = adress; 
        Description = description;
    }

}
