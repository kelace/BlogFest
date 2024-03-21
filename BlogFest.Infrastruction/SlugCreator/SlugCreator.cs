using BlogFest.Application.Abstract;
using SlugGenerator;

namespace BlogFest.Infrastruction.SlugCreator
{
    public class SlugCreator : ISlugCreator
    {
        public string CreateSlug(string word)
        {
            return word.GenerateSlug("-");
        }
    }
}
