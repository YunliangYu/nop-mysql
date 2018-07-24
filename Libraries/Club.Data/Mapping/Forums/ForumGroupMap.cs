using Club.Core.Domain.Forums;

namespace Club.Data.Mapping.Forums
{
    public partial class ForumGroupMap : SiteEntityTypeConfiguration<ForumGroup>
    {
        public ForumGroupMap()
        {
            this.ToTable("Forums_Group");
            this.HasKey(fg => fg.Id);
            this.Property(fg => fg.Name).IsRequired().HasMaxLength(200);
        }
    }
}
