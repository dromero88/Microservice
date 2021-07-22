using Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Domain.Contracts.Repositories
{
    public interface ICustomerRepository: IGenericRepository<Customer>
    {
    }
}
