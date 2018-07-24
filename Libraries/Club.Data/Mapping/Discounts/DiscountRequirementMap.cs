using Club.Core.Domain.Discounts;

namespace Club.Data.Mapping.Discounts
{
    public partial class DiscountRequirementMap : SiteEntityTypeConfiguration<DiscountRequirement>
    {
        public DiscountRequirementMap()
        {
            this.ToTable("DiscountRequirement");
            this.HasKey(requirement => requirement.Id);

            this.Ignore(requirement => requirement.InteractionType);
            this.HasMany(requirement => requirement.ChildRequirements)
                .WithOptional()
                .HasForeignKey(requirement => requirement.ParentId);
        }
    }
}