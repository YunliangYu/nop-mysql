using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class ProductCategoryMap : SiteEntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMap()
        {
            this.ToTable("Product_Category_Mapping");
            this.HasKey(pc => pc.Id);
            
            this.HasRequired(pc => pc.Category)
                .WithMany()
                .HasForeignKey(pc => pc.CategoryId);


            this.HasRequired(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);
        }
    }
}