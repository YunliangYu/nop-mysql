using Club.Core.Domain.Forums;

namespace Club.Data.Mapping.Forums
{
    public partial class ForumTopicMap : SiteEntityTypeConfiguration<ForumTopic>
    {
        public ForumTopicMap()
        {
            this.ToTable("Forums_Topic");
            this.HasKey(ft => ft.Id);
            this.Property(ft => ft.Subject).IsRequired().HasMaxLength(450);
            this.Ignore(ft => ft.ForumTopicType);

            this.HasRequired(ft => ft.Forum)
                .WithMany()
                .HasForeignKey(ft => ft.ForumId);

            this.HasRequired(ft => ft.Customer)
               .WithMany()
               .HasForeignKey(ft => ft.CustomerId)
               .WillCascadeOnDelete(false);
        }
    }
}
