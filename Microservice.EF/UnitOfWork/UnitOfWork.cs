using Microservice.EF.Data;
using Microservice.Domain.Contracts.Repositories;
using Microservice.Domain.Contracts.UnitOfWork;
using System;

namespace Microservice.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntitiesContext _context;

        public IEntityRepository Entities { get; }

        public ICustomerRepository Customer { get; }

        public UnitOfWork(EntitiesContext context,
           IEntityRepository entitiesRepository, ICustomerRepository customerRepository)
        {
            _context = context;
            Entities = entitiesRepository;
            Customer = customerRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
