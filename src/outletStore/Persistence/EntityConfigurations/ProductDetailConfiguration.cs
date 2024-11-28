using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
{
    public void Configure(EntityTypeBuilder<ProductDetail> builder)
    {
        builder.ToTable("ProductDetails").HasKey(pd => pd.Id);

        builder.Property(pd => pd.Id).HasColumnName("Id").IsRequired();
        builder.Property(pd => pd.ProductSize).HasColumnName("ProductSize");
        builder.Property(pd => pd.BedRoomCount).HasColumnName("BedRoomCount");
        builder.Property(pd => pd.BathCount).HasColumnName("BathCount");
        builder.Property(pd => pd.RoomCount).HasColumnName("RoomCount");
        builder.Property(pd => pd.GarageSize).HasColumnName("GarageSize");
        builder.Property(pd => pd.BuildYear).HasColumnName("BuildYear");
        builder.Property(pd => pd.Price).HasColumnName("Price");
        builder.Property(pd => pd.Location).HasColumnName("Location");
        builder.Property(pd => pd.VideoUrl).HasColumnName("VideoUrl");
        builder.Property(pd => pd.ProductId).HasColumnName("ProductId");
        builder.Property(pd => pd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pd => pd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pd => pd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(pd => pd.Product);

        builder.HasQueryFilter(pd => !pd.DeletedDate.HasValue);
    }
}