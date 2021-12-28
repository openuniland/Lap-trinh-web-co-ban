using BtlWebForm.Entity;
using BtlWebForm.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtlWebForm.Utils
{
    public class CommentUtils
    {
        public static string GetDay(DateTime dateTime)
        {
            DateTime dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime dateInput = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            TimeSpan timeSpan = dateNow - dateInput;
            return (timeSpan.Days == 0) ? "Hôm nay" : timeSpan.Days + " ngày trước"; ;
        }

        public static string HTMLComments(CommentOfAPost comments)
        {
            if (comments == null)
                return "";
            UserRepository userRepository = new UserRepository();
            string HTML = "";

            foreach (CommentLevel1Entity comment in comments.ListComment)
            {
                UserEntity userLv1 = userRepository.FindUserByID(comment.CommentMain.IDUser);


                // xử lý avt, trong avt chứa tên viết tắt, lấy các chữ cái đầu của fullname
                userLv1.Fullname = userLv1.Fullname.Trim();
                string[] words = userLv1.Fullname.Split(' ');
                string acronym = "";
                foreach(string word in words)
                {
                    acronym += word[0];
                }

                string html = @"<div class='detail_comment flex'  id='" + comment.IDCommentMain + @"'>

                                    <!-- avatar -->
                                    <div class='avatar_comment'>"
                                       + acronym +
                                    @"</div>

                                    <!-- User -->
                                    <div class='user_comment'>
                                        <div class='flex'>
                                            <h4>" + userLv1.Fullname + @"</h4>";
                                            if (userLv1.Role == Constant.ROLE_ADMIN)
                                                html += @"<span class='role'>Quản trị viên</span>";
                                        html +=  @"<span class='time'>" + GetDay(comment.CommentMain.TimeComment) + @"</span>
                                        </div>

                                        <!-- comment cua user -->
                                        <span class='content_comment'>"
                                            + comment.CommentMain.Content +
                                        @"</span>

                                        <!-- btn them comment lv2 -->
                                        <a id='xxx' class='btn_reply' onclick='addCommentLevel2(this)'>Trả lời</a>";

                                    // tạo 1 biến tránh null
                                    int num = comment.ListReply == null ? -1 : comment.ListReply.Count;

                                    for (int i = 0; i < num; i++)
                                    {
                                          UserEntity userLv2 = userRepository.FindUserByID(comment.ListReply[i].IDUser);
                                                if (userLv2 == null)
                                                     continue;
                                            string htmlReply = @"<!-- reply will append to here -->
                                                                                    <div class='reply'>
                                                                                        <div class='user_comment'>
                                                                                            <div class='flex'>
                                                                                                <h4>" + userLv2.Fullname + @"</h4>";

                                            if (userLv2.Role == Constant.ROLE_ADMIN)
                                                htmlReply += @"<span class='role'>Quản trị viên</span>";
                                                           htmlReply +=   @"<span class='time'>" + GetDay(comment.ListReply[i].TimeComment) + @"</span>
                                                                    </div>
                                                                    <span class='content_comment'>"
                                                                        + comment.ListReply[i].Content +
                                                                    @"</span>
                                                                </div>
                                                            </div>";
                                          html += htmlReply;
                                    }

                                            html +=   @"</div>
                                                    </div>";
                HTML += html;
            }
            

            return HTML;
        }

    }
}