#region copyright

/*

Harrison1 COSC 470 2019

File = BaseEntity.cs

Author = Taylor Adam

Date = 2019-11-19

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Taylor Adam		2019-11-19			Added Headers

*/

#endregion copyright

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