using System;
using System.Collections.Generic;
using System.Text;

namespace Tasky.Shared.BusinessLayer.Contracts
{
    public abstract class BusinessEntityBase : IBusinessEntity
    {
        public BusinessEntityBase()
        {
        }

        /// <summary>
        /// Gets or sets the Database ID.
        /// </summary>
        //[PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
