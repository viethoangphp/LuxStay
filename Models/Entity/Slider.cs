namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public partial class Slider
    {
        public int SliderID { get; set; }

        [StringLength(150)]
        public string Img { get; set; }

        public int? Status { get; set; }

        public int? Location { get; set; }
    }
}
