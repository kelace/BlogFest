namespace BlogFest.Domain.Content.ContentCreating
{
    public interface IContentCreatorRepository
    {
        Task UpdateAsync(ContentCreator contentCreator);
        Task<ContentCreator> GetContentCreatorById(Guid id);
        Task<string> GetSlugForPost(Guid id);
    }
}
