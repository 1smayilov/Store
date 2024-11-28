using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.Title).HasColumnName("Title");
        builder.Property(p => p.Price).HasColumnName("Price");
        builder.Property(p => p.CoverImage).HasColumnName("CoverImage");
        builder.Property(p => p.City).HasColumnName("City");
        builder.Property(p => p.District).HasColumnName("District");
        builder.Property(p => p.Adress).HasColumnName("Adress");
        builder.Property(p => p.Description).HasColumnName("Description");
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId");
        builder.Property(p => p.EmployeeId).HasColumnName("EmployeeId");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);

        builder.HasOne(p => p.Category);
        builder.HasOne(p => p.Employee);
        builder.HasMany(p => p.ProductDetails);

    }
}