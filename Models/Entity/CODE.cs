namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CODE")]
    public partial class CODE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CODE()
        {
            Rooms = new HashSet<Room>();
        }

        public int CodeID { get; set; }

        [Column("CODE")]
        [StringLength(50)]
        public string CODE1 { get; set; }

        public int? Status { get; set; }

        public int? price { get; set; }

        public DateTime? Check_in { get; set; }

        public DateTime? Check_out { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
