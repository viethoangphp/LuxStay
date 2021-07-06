namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        public int ImageID { get; set; }

        [StringLength(150)]
        public string Url { get; set; }

        public int? Status { get; set; }

        public int? Type { get; set; }

        public int RoomID { get; set; }

        public virtual Room Room { get; set; }
    }
}
