using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtlWebForm.Entity
{
    public class PostEntity
    {
        public int IDProduct { get; set; }
        public string Content { get; set; }
        public List<string> ListImage { get; set; }
        public PostEntity() { }
        public PostEntity(int IDProduct, string Content, List<string> ListImage)
        {
            this.IDProduct = IDProduct;
            this.Content = Content;
            this.ListImage = ListImage;
        }
    }
}