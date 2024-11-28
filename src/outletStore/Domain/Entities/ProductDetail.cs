using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProductDetail:Entity<int>
{
    public int ProductSize { get; set; }
    public int BedRoomCount { get; set; }
    public int BathCount { get; set; }
    public int RoomCount { get; set; }
    public int GarageSize { get; set; }
    public char BuildYear { get; set; }
    public double Price { get; set; }
    public string Location { get; set; }
    public string VideoUrl { get; set; }

    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }
}
