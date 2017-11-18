using Homework5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Homework5.DAL
{
    public class AddressChangeContext : DbContext
    {
            /// <summary>
            /// Context constructor
            /// </summary>
            public AddressChangeContext() : base("name=theDBContext") { }

            /// <summary>
            /// Method that gets and sets each record in the table
            /// </summary>
            public virtual DbSet<AddressChange> AddressChanges { get; set; }

    }
}