using Microservice.EF.Data;
using Microservice.Domain;
using Microservice.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.Domain.Entities;

namespace Microservice.EF.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EntitiesContext context) : base(context)
        {

        }
    }
}
