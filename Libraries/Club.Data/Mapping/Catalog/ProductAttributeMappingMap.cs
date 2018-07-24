using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class ProductAttributeMappingMap : SiteEntityTypeConfiguration<ProductAttributeMapping>
    {
        public ProductAttributeMappingMap()
        {
            this.ToTable("Product_ProductAttribute_Mapping");
            this.HasKey(pam => pam.Id);
            this.Ignore(pam => pam.AttributeControlType);

            this.HasRequired(pam => pam.Product)
                .WithMany(p => p.ProductAttributeMappings)
                .HasForeignKey(pam => pam.ProductId);

            this.HasRequired(pam => pam.ProductAttribute)
                .WithMany()
                .HasForeignKey(pam => pam.ProductAttributeId);
        }
    }
}