namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Utility")]
    public partial class Utility
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utility()
        {
            UtilityDetails = new HashSet<UtilityDetail>();
        }

        public int UtilityID { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public int? ParentID { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string Icon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UtilityDetail> UtilityDetails { get; set; }
    }
}
