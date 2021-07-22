using Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Domain.Contracts.DomainService
{
    public interface IDSEntity
    {
        Task<Entity> Insert(Entity entity);

        Entity Modify(Entity entity);

        void Delete(Entity entity);

        Task<IEnumerable<Entity>> Get(Expression<Func<Entity, bool>> where = null);
    }
}
