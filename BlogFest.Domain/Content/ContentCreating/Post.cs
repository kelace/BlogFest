using BlogFest.Domain.Base;
using BlogFest.Domain.Content;
using System.Threading;

namespace BlogFest.Domain.Content.ContentCreating
{
    public class Post : Entity
    {
        public Guid? ImageTitle { get; private set; }
        public string ContentText { get; private set; }
        public string ContentHTML { get; private set; }
        public string Title { get; private set; }
        public PostStatus Status { get; private set; }
        public Guid CreatedBy { get; private set; }
        public List<Guid> Categories { get; private set; }
        public string Slug { get; private set; }

        public const int DefaultContentSizeMin = 100;
        public const int DefaultContentSizeMax = 10000;

        public const int DefaultTitleSizeMin = 5;
        public const int DefaultTitleSizeMax = 40;

        public const string DefaultTitle = "Untitled";
        public const string DefaultText = "Could artificial intelligence have been used to prevent the high-profile Target breach? The concept is not so far-fetched. Organizations such as Mastercard and RBS WorldPay have long relied on artificial intelligence to detect fraudulent transaction patterns and prevent card.";

        public Post(Guid Id, string content, string title, PostStatus status, Guid createdBy, List<Guid> categories, string slug) : base(Id)
        {
            ContentText = content;
            Title = title;
            Status = status;
            CreatedBy = createdBy;
            Categories = categories ?? new List<Guid>();
            Slug = slug;
        }

        public void Publish()
        {
            Status = PostStatus.Published;
        }

        public Result<SuccessInfo, Error> Edit(string contentText, string contentHTML, string title, string slug, List<Guid> categories, PostStatus status = null)
        {
            if (contentText.Length < DefaultContentSizeMin || contentText.Length > DefaultContentSizeMax) return PostErros.NotAllowedSize; 
            if (title.Length < DefaultTitleSizeMin || title.Length > DefaultTitleSizeMax) return PostErros.NotAllowedSize; 

            ContentText = contentText;
            ContentHTML = contentHTML;
            Title = title;
            Categories = categories ?? Categories;
            Status = status ?? Status;
            Slug = slug ?? Slug;

            return new SuccessInfo
            {
                Id = Id,
                Slug = Slug
            };
        }

        public Guid? ChangeImageTitle(Guid? image)
        {
            if (ImageTitle == image) return ImageTitle;
            if (image == null) return ImageTitle;

            ImageTitle = image;

            return image;
        }
    }
}
