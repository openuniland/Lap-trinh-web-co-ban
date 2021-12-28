using BtlWebForm.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtlWebForm.Repository
{
    public class CommentRepository
    {
        FileIO file = new FileIO();
        public List<CommentOfAPost> FindAllComments()
        {
            string jsonData = file.ReadFileJson(Constant.DATA_COMMENT);
            return JsonConvert.DeserializeObject<List<CommentOfAPost>>(jsonData);
        }

        public CommentOfAPost FindListCommentsOfProduct(int IDProduct)
        {
            List<CommentOfAPost> comments = FindAllComments();
            if (comments == null)
                return null;
            foreach (CommentOfAPost comment in comments)
            {
                if (comment.IDProduct == IDProduct)
                    return comment;
            }
            return null;
        }

        public void SaveCommentLevel1(ref CommentLevel1Entity commentLevel1, int IDProduct)
        {
            List<CommentOfAPost> listCommentOfAllProduct = FindAllComments();
            

            // nếu file rỗng thì tạo comment cho bài viết luôn
            if (listCommentOfAllProduct == null)
            {
                listCommentOfAllProduct = new List<CommentOfAPost>();
                CommentOfAPost commentOfAPost = new CommentOfAPost();
                commentOfAPost.IDProduct = IDProduct;

                // tạo id cho comment đầu tiên của bài viết
                commentLevel1.IDCommentMain = 1;
                commentOfAPost.ListComment = new List<CommentLevel1Entity>();
                commentOfAPost.ListComment.Add(commentLevel1);
                listCommentOfAllProduct.Add(commentOfAPost);
                file.WriteFileJson(Constant.DATA_COMMENT, JsonConvert.SerializeObject(listCommentOfAllProduct));
                return;
            }
            else
            {
                // file json đã có giá trị, đi kiểm tra xem post đã có cmt chưa
                foreach (CommentOfAPost commentOfAPost in listCommentOfAllProduct)
                {
                    // nếu mà có rồi thì thêm vào thôi
                    if (commentOfAPost.IDProduct == IDProduct)
                    {
                        commentLevel1.IDCommentMain = commentOfAPost.ListComment[commentOfAPost.ListComment.Count - 1].IDCommentMain + 1;
                        commentOfAPost.ListComment.Add(commentLevel1);
                        listCommentOfAllProduct.Add(commentOfAPost);
                        file.WriteFileJson(Constant.DATA_COMMENT, JsonConvert.SerializeObject(listCommentOfAllProduct));
                        return;
                    }
                }

                // nếu mà post chưa có bình luận
                commentLevel1.IDCommentMain = 1;
                CommentOfAPost comment = new CommentOfAPost();
                comment.IDProduct = IDProduct;
                comment.ListComment = new List<CommentLevel1Entity>();
                comment.ListComment.Add(commentLevel1);
                listCommentOfAllProduct.Add(comment);
                file.WriteFileJson(Constant.DATA_COMMENT, JsonConvert.SerializeObject(listCommentOfAllProduct));
                return;
            }
            
        }

        public void SaveCommentLevel2(SimpleComment commentReply, int IDProduct, int IDCommentMain)
        {
            List<CommentOfAPost> listCommentOfAllProduct = FindAllComments();
            if (listCommentOfAllProduct == null)
            {
                // vì không có comment thì sao có reply
                return;
            }
            foreach (CommentOfAPost commentOfAPost in listCommentOfAllProduct)
            {
                if (commentOfAPost.IDProduct == IDProduct)
                {
                    if (commentOfAPost.ListComment == null)
                        return; // vì ko có comment thì sao có reply
                    
                    // tìm ID của comment
                    foreach (CommentLevel1Entity commentLevel1 in commentOfAPost.ListComment)
                    {
                        if (commentLevel1.IDCommentMain == IDCommentMain)
                        {
                            if (commentLevel1.ListReply == null)
                                commentLevel1.ListReply = new List<SimpleComment>();
                            commentLevel1.ListReply.Add(commentReply);
                            file.WriteFileJson(Constant.DATA_COMMENT, JsonConvert.SerializeObject(listCommentOfAllProduct));
                            return;
                        }
                    }
                    
                }
            }
        }
    }

}