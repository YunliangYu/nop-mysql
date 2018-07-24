using Club.Core.Domain.Forums;

namespace Club.Data.Mapping.Forums
{
    public partial class ForumPostVoteMap : SiteEntityTypeConfiguration<ForumPostVote>
    {
        public ForumPostVoteMap()
        {
            this.ToTable("Forums_PostVote");
            this.HasKey(fpv => fpv.Id);

            this.HasRequired(fpv => fpv.ForumPost)
                .WithMany()
                .HasForeignKey(fpv => fpv.ForumPostId)
                .WillCascadeOnDelete(true);
        }
    }
}
