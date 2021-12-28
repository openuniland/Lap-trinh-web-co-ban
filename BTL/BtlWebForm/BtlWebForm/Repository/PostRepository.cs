using BtlWebForm.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtlWebForm.Repository
{
    public class PostRepository
    {
        FileIO file = new FileIO();
        public List<PostEntity> FindAllPosts()
        {
            string postJson = file.ReadFileJson(Constant.DATA_POSTS);
            return JsonConvert.DeserializeObject<List<PostEntity>>(postJson);
        }
        public PostEntity FindPostByIDProduct(int IDProduct)
        {
            List<PostEntity> posts = FindAllPosts();
            if (posts == null)
                return null;
            foreach (PostEntity post in posts)
            {
                if (post.IDProduct == IDProduct)
                    return post;
            }
            return null;
        }

        public void SavePost(PostEntity post)
        {
            List<PostEntity> posts = FindAllPosts();
            if (posts == null)
                posts = new List<PostEntity>();
            posts.Add(post);
            file.WriteFileJson(Constant.DATA_POSTS, JsonConvert.SerializeObject(posts));
        }
    }
}