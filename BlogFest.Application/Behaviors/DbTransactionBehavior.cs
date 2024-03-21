using BlogFest.Application.Abstract;
using BlogFest.Application.Services.Abstract;
using MediatR;

namespace BlogFest.Application.Behaviors
{
    public class DbTransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IApplicationCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        public DbTransactionBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                var result = await next();
                await _unitOfWork.CommitTransaction();
                return result;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
