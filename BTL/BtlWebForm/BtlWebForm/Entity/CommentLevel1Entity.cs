using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtlWebForm.Entity
{
    public class CommentLevel1Entity
    {
        public int IDCommentMain { get; set; }
        public SimpleComment CommentMain { get; set; }
        public List<SimpleComment> ListReply { get; set; }
    }
}