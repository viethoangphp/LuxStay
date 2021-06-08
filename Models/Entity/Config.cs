namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Config")]
    public partial class Config
    {
        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Logo { get; set; }

        [StringLength(15)]
        public string Hotline { get; set; }

        [StringLength(50)]
        public string Facebook { get; set; }

        [StringLength(150)]
        public string Copyright { get; set; }

        public int ID { get; set; }
    }
}
