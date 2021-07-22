using Microservice.EF.Data;
using Microservice.Domain;
using Microservice.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microservice.Domain.Entities;

namespace Microservice.EF.Repositories
{
    public class EntityRepository : GenericRepository<Entity>, IEntityRepository
    {
        public EntityRepository(EntitiesContext context) : base(context)
        {

        }
    }
}
