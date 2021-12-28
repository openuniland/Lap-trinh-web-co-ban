using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtlWebForm.Entity
{
    public class SimpleComment
    {
        public int IDUser { get; set; }
        public string Content { get; set; }
        public DateTime TimeComment { get; set; }
        public SimpleComment() { }
        public SimpleComment(int id, string content)
        {
            IDUser = id;
            Content = content;
        }
    }
}