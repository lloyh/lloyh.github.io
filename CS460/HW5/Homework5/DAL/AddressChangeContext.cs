using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework5.Models;

namespace Homework5.DAL
{
    /// <summary>
    /// DB context class for AddressChange
    /// </summary>
    public class AddressChangeContext : DbContext
    {
        /// <summary>
        /// Context constructor
        /// </summary>
        public AddressChangeContext() : base("name=theDBContext") { }

        /// <summary>
        /// Method that gets and sets each record in the table
        /// </summary>
        public virtual DbSet<AddressChange> AddressChange { get; set; }

    }
}