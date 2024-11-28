using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Employee:Entity<int>
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    public Employee()
    {
        Products = new HashSet<Product>();
    }
}
