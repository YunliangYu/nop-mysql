using Club.Core.Domain.Topics;

namespace Club.Data.Mapping.Topics
{
    public partial class TopicTemplateMap : SiteEntityTypeConfiguration<TopicTemplate>
    {
        public TopicTemplateMap()
        {
            this.ToTable("TopicTemplate");
            this.HasKey(t => t.Id);
            this.Property(t => t.Name).IsRequired().HasMaxLength(400);
            this.Property(t => t.ViewPath).IsRequired().HasMaxLength(400);
        }
    }
}