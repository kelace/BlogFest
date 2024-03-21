using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BlogFest.Data;
using BlogFest.Data.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using BlogFest.Application.Abstract;
using System.Transactions;

namespace BlogFest.Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;
        private IMediator _mediator;
        private IDomainEventStorage _domainEventService;
        private ILogger<UnitOfWork> _logger;
        private IDbContextTransaction _dbTransaction;
        public UnitOfWork(ApplicationDbContext context, IMediator mediator, IDomainEventStorage domainEventService, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _mediator = mediator;
            _domainEventService = domainEventService;
            _logger = logger;
        }
        public async Task BeginTransaction()
        {
            if (_dbTransaction == null) _dbTransaction = await _context.Database.BeginTransactionAsync();

        }

        public async Task CommitTransaction()
        {
            if (_dbTransaction != null) _dbTransaction.CommitAsync();
        }

        public void Dispose()
        {
            if(_dbTransaction != null) _dbTransaction.Dispose();
        }

        public async Task RollbackTransaction()
        {
            if (_dbTransaction != null) _dbTransaction.RollbackAsync();
        }
        public async Task SaveAsync()
        {

            await _mediator.ApplyDomainEvents(_domainEventService);

            await _context.SaveChangesAsync();

        }
    }
}
