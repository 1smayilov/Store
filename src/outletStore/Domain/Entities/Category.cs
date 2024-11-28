using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Category:Entity<int>
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<Product> Products { get; set; }

    public Category()
    {
        Products = new HashSet<Product>();
    }

    public Category(int id, string name, bool status) : this()
    {
        Id = id;
        Name = name;
        Status = status;
    }


}
