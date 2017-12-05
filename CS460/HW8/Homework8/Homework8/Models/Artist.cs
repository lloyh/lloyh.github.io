namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            ArtWorks = new HashSet<ArtWork>();
        }

        public int ArtistID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Artist Name")]
        public string ArtistName { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [ValidateDate]
        [Display(Name ="Birth Date")]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Birth City")]
        public string BirthCity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArtWork> ArtWorks { get; set; }
    }
}
