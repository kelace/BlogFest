using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Domain.Content.ContentConsuming
{
    public interface IContentConsumerRepository
    {
        Task<ContentConsumer> GetContentConsumerById(Guid id, Guid postId);
        Task UpdateAsync(ContentConsumer consumer);
    }
}
