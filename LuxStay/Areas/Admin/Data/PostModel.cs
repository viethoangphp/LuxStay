using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxStay.Areas.Admin.Data
{
    public class PostModel
    {
        [Required]
        public int postID { get; set; }
        [Required]
        public string postTitle { get; set; }
        [Required]
        public string postDesc { get; set; }
        [Required]
        public string postContent { get; set; }
        [Required]
        public string postStatus { get; set; }
        public string postAvatar { get; set; }
        public int Create_by { get; set; }
        public HttpPostedFileBase avatarFile { get; set; }

    }
}