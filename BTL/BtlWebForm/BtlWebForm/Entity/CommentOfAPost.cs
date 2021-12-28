using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtlWebForm.Entity
{
    public class CommentOfAPost
    {
        // class này dể fix lại những j làm xót :((

        public int IDProduct { get; set; }
        public List<CommentLevel1Entity> ListComment { get; set; }
    }
}