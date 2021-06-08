namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Advice")]
    public partial class Advice
    {
        public int AdviceID { get; set; }

        public int? Support_by { get; set; }

        [StringLength(150)]
        public string CustomerName { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        public int? Status { get; set; }

        public DateTime? Create_At { get; set; }

        public virtual User User { get; set; }
    }
}
