using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class ProductSpecificationAttributeMap : SiteEntityTypeConfiguration<ProductSpecificationAttribute>
    {
        public ProductSpecificationAttributeMap()
        {
            this.ToTable("Product_SpecificationAttribute_Mapping");
            this.HasKey(psa => psa.Id);

            this.Property(psa => psa.CustomValue).HasMaxLength(4000);

            this.Ignore(psa => psa.AttributeType);

            this.HasRequired(psa => psa.SpecificationAttributeOption)
                .WithMany()
                .HasForeignKey(psa => psa.SpecificationAttributeOptionId);


            this.HasRequired(psa => psa.Product)
                .WithMany(p => p.ProductSpecificationAttributes)
                .HasForeignKey(psa => psa.ProductId);
        }
    }
}