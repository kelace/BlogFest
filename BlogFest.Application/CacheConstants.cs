using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application
{
    public static class CacheConstants
    {
        public const string PostSlugCacheKey = "post-";

        public static string GetPostSlugCacheKey(string postSlug)
        {
            return PostSlugCacheKey + postSlug;
        }
    }
}
