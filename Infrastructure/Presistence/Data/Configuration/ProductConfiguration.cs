namespace Presistence.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p=>p.ProductType)
                .WithMany()
                .HasForeignKey(p => p.TypeId);

            builder.HasOne(p => p.ProductBrand)
                .WithMany()
               .HasForeignKey(p => p.BrandId);

            builder.Property(p => p.Price).HasColumnType("decimal(15,2)");  
        }
    }
}
