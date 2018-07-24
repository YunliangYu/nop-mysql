using Club.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Data.Mapping.Directory
{
    public partial class CityMap:SiteEntityTypeConfiguration<City>
    {
        public CityMap()
        {
            this.ToTable("City");
            this.HasKey(p => p.Id);
            this.Property(sp => sp.Name).IsRequired().HasMaxLength(100);
            this.Property(sp => sp.Abbreviation).HasMaxLength(100);

            this.HasRequired(sp => sp.StateProvince)
               .WithMany(c => c.Citys)
               .HasForeignKey(sp => sp.StateProvinceId);
        }
    }
}
