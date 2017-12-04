namespace Homework7.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SearchesContext : DbContext
    {
        public SearchesContext()
            : base("name=SearchesContext")
        {
        }

        public virtual DbSet<Search> Searches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

