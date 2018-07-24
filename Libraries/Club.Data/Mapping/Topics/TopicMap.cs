using Club.Core.Domain.Topics;

namespace Club.Data.Mapping.Topics
{
    public class TopicMap : SiteEntityTypeConfiguration<Topic>
    {
        public TopicMap()
        {
            this.ToTable("Topic");
            this.HasKey(t => t.Id);
        }
    }
}
