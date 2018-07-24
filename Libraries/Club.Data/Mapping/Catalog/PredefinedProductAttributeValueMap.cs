using Club.Core.Domain.Catalog;

namespace Club.Data.Mapping.Catalog
{
    public partial class PredefinedProductAttributeValueMap : SiteEntityTypeConfiguration<PredefinedProductAttributeValue>
    {
        public PredefinedProductAttributeValueMap()
        {
            this.ToTable("PredefinedProductAttributeValue");
            this.HasKey(pav => pav.Id);
            this.Property(pav => pav.Name).IsRequired().HasMaxLength(400);

            this.Property(pav => pav.PriceAdjustment).HasPrecision(18, 4);
            this.Property(pav => pav.WeightAdjustment).HasPrecision(18, 4);
            this.Property(pav => pav.Cost).HasPrecision(18, 4);

            this.HasRequired(pav => pav.ProductAttribute)
                .WithMany()
                .HasForeignKey(pav => pav.ProductAttributeId);
        }
    }
}