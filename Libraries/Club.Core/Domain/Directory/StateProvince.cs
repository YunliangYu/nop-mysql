
using Club.Core.Domain.Localization;
using System.Collections.Generic;

namespace Club.Core.Domain.Directory
{
    /// <summary>
    /// Represents a state/province
    /// </summary>
    public partial class StateProvince : BaseEntity, ILocalizedEntity
    {
        private ICollection<City> _citys;
        /// <summary>
        /// Gets or sets the country identifier
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets the state/provinces
        /// </summary>
        public virtual ICollection<City> Citys
        {
            get { return _citys ?? (_citys = new List<City>()); }
            protected set { _citys = value; }
        }
    }

}
