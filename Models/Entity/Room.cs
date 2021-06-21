namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            Bills = new HashSet<Bill>();
            Images = new HashSet<Image>();
            CODEs = new HashSet<CODE>();
            Utilities = new HashSet<Utility>();
        }

        public int RoomID { get; set; }

        public int CatID { get; set; }

        public int? SaleID { get; set; }

        public int LocationID { get; set; }

        [StringLength(150)]
        public string RoomName { get; set; }

        public int? Area { get; set; }

        public int? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(50)]
        public string Avatar { get; set; }

        public int? BedRoom { get; set; }

        public int? BathRoom { get; set; }

        public int? BedNumber { get; set; }

        public int? PeopleMax { get; set; }

        [Column(TypeName = "ntext")]
        public string Note { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        public int? MaxStay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }

        public virtual Location Location { get; set; }

        public virtual RoomCategory RoomCategory { get; set; }

        public virtual Sale Sale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CODE> CODEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utility> Utilities { get; set; }
    }
}
