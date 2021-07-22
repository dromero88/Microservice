using Microservice.Domain;
using Microservice.Domain.Contracts.DomainService;
using Microservice.Domain.Contracts.Repositories;
using Microservice.Domain.Contracts.UnitOfWork;
using Microservice.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntitiesController : ControllerBase
    {
        private readonly IDSEntity _dsEntity;

        private readonly ILogger<EntitiesController> _logger;

        public EntitiesController(ILogger<EntitiesController> logger, IDSEntity dsEntity)
        {
            _logger = logger;
            _dsEntity = dsEntity;
        }

        [HttpGet]
        public async Task <IEnumerable<Entity>> Get()
        {
            return await _dsEntity.Get();
        }

        [HttpGet("{id:int}")]
        public async Task<Entity> Get(int id)
        {
            return (await _dsEntity.Get(b => b.Id == id)).FirstOrDefault();
        }

        [HttpPost]
        public async Task<ActionResult<Entity>> Post(Entity entity)
        {
            return await _dsEntity.Insert(entity);
        }

        [HttpPut]
        public ActionResult<Entity> Put(Entity entity)
        {
            return _dsEntity.Modify(entity);
        }

        [HttpDelete]
        public ActionResult Delete(Entity entity)
        {
            _dsEntity.Delete(entity);

            return Ok();
        }

        [HttpPatch("{id:int}")]
        public async Task <ActionResult<Entity>> JsonPatchForDynamic (int id, [FromBody] JsonPatchDocument patch)
        {
            var originalentity = (await _dsEntity.Get(b => b.Id == id)).FirstOrDefault();

            if (originalentity == null) return NotFound();

            patch.ApplyTo(originalentity, (IObjectAdapter)ModelState);

            return _dsEntity.Modify(originalentity);
        }
    }
}
