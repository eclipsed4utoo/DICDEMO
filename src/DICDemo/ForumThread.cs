using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DICDemo
{
    class ForumThread
    {
        public Int64 ID;
        public string Icon;
        public string Title;
        public string Description;
        public string URL;
        public User CreatedUser;
        public int Replies;
        public int Views;
        public LastThreadPost LastPost;
    }
}
