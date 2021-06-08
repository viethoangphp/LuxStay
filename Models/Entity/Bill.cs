namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        public int BillID { get; set; }

        public int? Confirm_by { get; set; }

        public int? Create_by { get; set; }

        public int RoomID { get; set; }

        public DateTime? Create_At { get; set; }

        public DateTime? Check_in { get; set; }

        public DateTime? Check_out { get; set; }

        public int? Total { get; set; }

        public int? Adult { get; set; }

        public int? Kid { get; set; }

        public int? Baby { get; set; }

        public int? Status { get; set; }

        [StringLength(150)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        public int? Gender { get; set; }

        public virtual User User { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Room Room { get; set; }
    }
}
