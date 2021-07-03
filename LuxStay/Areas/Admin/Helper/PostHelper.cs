using LuxStay.Areas.Admin.Data;
using Models.DAO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxStay.Areas.Admin.Helper
{
    public class PostHelper
    {
        PostDAO dao = new PostDAO();
        public List<PostModel> getListPost()
        {
            List<Post> list = dao.getListAll();
            List<PostModel> listModel = new List<PostModel>();
            foreach (var item in list)
            {
                string st = "Hiển thị";
                if (item.Status == 0)
                {
                    st = "Ẩn";
                }
                PostModel post = new PostModel()
                {
                    postID = item.PostID,
                    postTitle = item.PostName,
                    postDesc = item.Descprition,
                    postAvatar = item.Avatar,
                    postContent = item.ContentPost,
                    postStatus = st
                };
                listModel.Add(post);
            }
            return listModel;
        }

        public int AddPost(PostModel model)
        {
            int st = Convert.ToInt32(model.postStatus);
            Post post = new Post()
            {
                Avatar = model.postAvatar,
                PostName = model.postTitle,
                Descprition = model.postDesc,
                ContentPost = model.postContent,
                Create_by = model.Create_by,
                Status = st
            };
            return dao.Add(post);
        }
        
        public int DeletePost(int id)
        {
            return dao.Delete(id);
        }
    }
}