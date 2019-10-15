using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisPharmacy.App.Data.Entities
{
    /// <summary>
    /// A base entity that can be extended to include all of the fields we would like in all our entity's
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// description of the entity
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date time that the entity was created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date time that the entity was updated
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}