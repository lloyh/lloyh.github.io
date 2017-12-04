namespace Homework7.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Search
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string QUERY { get; set; }

        [Required]
        [StringLength(100)]
        public string IP_ADDRESS { get; set; }

        [Required]
        [StringLength(100)]
        public string USERAGENT { get; set; }

        public DateTime SEARCH_DATE { get; set; }
    }
}
