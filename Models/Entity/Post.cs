namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        public int PostID { get; set; }

        [StringLength(150)]
        public string PostName { get; set; }

        [Column(TypeName = "ntext")]
        public string ContentPost { get; set; }

        [StringLength(150)]
        public string Descprition { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string Avatar { get; set; }

        public int Create_by { get; set; }

        public virtual User User { get; set; }
    }
}
