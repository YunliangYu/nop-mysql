using Club.Core.Domain.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Mapping.News
{
    public partial class NewsPictureMap : SiteEntityTypeConfiguration<NewsPicture>
    {
        public NewsPictureMap()
        {
            this.ToTable("News_Picture_Mapping");
            this.HasKey(np => np.Id);

            this.HasRequired(np => np.Picture)
                .WithMany()
                .HasForeignKey(np => np.PictureId);

            this.HasRequired(np => np.NewsItem)
                .WithMany(n => n.NewsPictures)
                .HasForeignKey(np => np.NewsId);
        }
    }
}
