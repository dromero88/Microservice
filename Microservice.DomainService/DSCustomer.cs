using Microservice.Domain;
using Microservice.Domain.Contracts.DomainService;
using Microservice.Domain.Contracts.UnitOfWork;
using Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DomainService
{
    public class DSCustomer : IDSCustomer
    {
        private IUnitOfWork _unitOfWork;

        public DSCustomer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> Get(Expression<Func<Customer, bool>> where = null)
        {
            if (where == null)
                return await _unitOfWork.Customer.GetAll();

            return await _unitOfWork.Customer.Get(where);
        }

        public Task<Customer> Insert(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Modify(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
