using Microservice.Domain.Contracts.Repositories;
using System;

namespace Microservice.Domain.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityRepository Entities { get; }

        ICustomerRepository Customer { get; }

        void SaveChanges();
    }
}
