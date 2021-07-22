using Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Domain.Contracts.DomainService
{
    public interface IDSCustomer
    {
        Task<Customer> Insert(Customer customer);

        Customer Modify(Customer customer);

        void Delete(Customer customer);

        Task<IEnumerable<Customer>> Get(Expression<Func<Customer, bool>> where = null);
    }
}
