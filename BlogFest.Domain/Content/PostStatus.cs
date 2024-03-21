using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.Content
{
    public class PostStatus : Enumeration
    {
        public static PostStatus Draft = new(1, nameof(Draft));
        public static PostStatus Published = new(2, nameof(Published));
        public static PostStatus Hidden = new(3, nameof(Hidden));

        public PostStatus(int id, string name) : base(id, name)
        {
        }

        public static implicit operator string(PostStatus status) => status.ToString();
        public static implicit operator PostStatus(string status)
        {
            var existedStatus = GetByName<PostStatus>(status);

            if (existedStatus == null) return null;

            return existedStatus;
        }

    }
}
