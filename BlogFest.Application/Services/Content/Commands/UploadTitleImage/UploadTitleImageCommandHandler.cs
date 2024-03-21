using MediatR;
using BlogFest.Domain.Base;
using BlogFest.Domain.Content;
using BlogFest.Application.Abstract;
using BlogFest.Application.Services.Media.Results;

namespace BlogFest.Application.Services.Content.Commands.UploadTitleImage
{
    public class UploadTitleImageCommandHandler : IRequestHandler<UploadTitleImageCommand, Result<SuccesUploadResult, Error>>
    {
        private readonly IPostImageLoader _postImageLoader;
        private readonly IUnitOfWork _unitOfWork;
        public UploadTitleImageCommandHandler(IPostImageLoader postImageLoader, IUnitOfWork unitOfWork)
        {
            _postImageLoader = postImageLoader;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<SuccesUploadResult, Error>> Handle(UploadTitleImageCommand request, CancellationToken cancellationToken)
        {

            if (request == null) return PostErros.TitleImageIsNull;

            var result = await _postImageLoader.LoadTitleImage(request.Image, request.PostId);

            if (result.IsError) return result.Error;

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                await _postImageLoader.RemoveTitleImage(result.Value.ImageId);
                throw;
            }

            return result;
        }
    }
}
