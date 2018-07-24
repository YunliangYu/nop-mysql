using Club.Core.Domain.Vendors;

namespace Club.Data.Mapping.Vendors
{
    public partial class VendorNoteMap : SiteEntityTypeConfiguration<VendorNote>
    {
        public VendorNoteMap()
        {
            this.ToTable("VendorNote");
            this.HasKey(vn => vn.Id);
            this.Property(vn => vn.Note).IsRequired();

            this.HasRequired(vn => vn.Vendor)
                .WithMany(v => v.VendorNotes)
                .HasForeignKey(vn => vn.VendorId);
        }
    }
}