using Club.Core.Domain.Media;

namespace Club.Data.Mapping.Media
{
    public partial class DownloadMap : SiteEntityTypeConfiguration<Download>
    {
        public DownloadMap()
        {
            this.ToTable("Download");
            this.HasKey(p => p.Id);
            this.Property(p => p.DownloadBinary).IsMaxLength();
        }
    }
}