using Club.Core.Domain.Directory;
using Club.Core.Domain.Localization;
using Club.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Core.Domain.Directory
{
    public partial class City : BaseEntity, ILocalizedEntity
    {
        public int StateProvinceId { get; set; }

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

        public StateProvince StateProvince { get; set; }

    }
}
