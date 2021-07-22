using Microservice.Domain;
using Microservice.Domain.Contracts.DomainService;
using Microservice.Domain.Contracts.UnitOfWork;
using Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DomainService
{
    public class DSEntity : IDSEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public DSEntity(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Entity entity)
        {
            _unitOfWork.Entities.Delete(entity);

            _unitOfWork.SaveChanges();
        }

        public Entity Modify(Entity entity)
        {
            var updatedentity = _unitOfWork.Entities.Update(entity);

            _unitOfWork.SaveChanges();

            return updatedentity;
        }

        public async Task<IEnumerable<Entity>> Get(Expression<Func<Entity, bool>> where = null)
        {
            if (where == null)
                return await _unitOfWork.Entities.GetAll();

            return await _unitOfWork.Entities.Get(where);
        }

        public async Task<Entity> Insert(Entity entity)
        {
            var savedentity = await _unitOfWork.Entities.Add(entity);

            _unitOfWork.SaveChanges();

            return savedentity;
        }

        
    }
}
