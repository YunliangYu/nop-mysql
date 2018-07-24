using Club.Core.Domain.Polls;

namespace Club.Data.Mapping.Polls
{
    public partial class PollVotingRecordMap : SiteEntityTypeConfiguration<PollVotingRecord>
    {
        public PollVotingRecordMap()
        {
            this.ToTable("PollVotingRecord");
            this.HasKey(pr => pr.Id);

            this.HasRequired(pvr => pvr.PollAnswer)
                .WithMany(pa => pa.PollVotingRecords)
                .HasForeignKey(pvr => pvr.PollAnswerId);

            this.HasRequired(cc => cc.Customer)
                .WithMany()
                .HasForeignKey(cc => cc.CustomerId);
        }
    }
}