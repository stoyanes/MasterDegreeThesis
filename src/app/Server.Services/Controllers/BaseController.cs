using Server.Data;
using Server.Data.Repositories;
using System.Linq;
using System.Web.Http;

namespace Server.Services.Controllers
{
    //[Authorize(Roles="admin, hr")]
    public class BaseController<TEntity> : ApiController where TEntity : class
    {
        protected IRepository<TEntity> entityRepository = new Repository<TEntity>(new ApplicationDbContext());

        //public BaseController(IRepository<TEntity> injectedEntityRepository)
        //{
        //    this.entityRepository = injectedEntityRepository;
        //}

        [HttpGet]
        [Route("")]
        public virtual IHttpActionResult GetAll()
        {
            var entities = entityRepository
                            .FindAll()
                            .ToList();
            return Ok(entities);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual IHttpActionResult GetById(int entityId)
        {
            TEntity entity = entityRepository.FindById(entityId);

            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        public virtual IHttpActionResult CreateEntity([FromBody] TEntity newEntity)
        {
            if (ModelState.IsValid)
            {
                TEntity createdEntity = entityRepository.Create(newEntity);
                // TODO needs to add ID of created resourse
                string createdLocation = string.Format("{0}/{1}", Request.RequestUri.ToString(), "");
                return Created(createdLocation, createdEntity);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("")]
        public virtual IHttpActionResult UpdateEntity([FromBody] TEntity newEntity)
        {
            if (ModelState.IsValid)
            {
                entityRepository.Update(newEntity);
                entityRepository.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual IHttpActionResult DeleteEntity(int id)
        {
            entityRepository.Delete(id);
            bool deleteResult = entityRepository.SaveChanges();
            if (deleteResult)
            {
                return Ok();
            }
            else
            {
                // TODO some better error here?
                return NotFound();
            }
        }
    }
}
