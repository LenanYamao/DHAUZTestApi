using DHAUZ_Api.Data;
using DHAUZ_Api.Models;
using DHAUZ_Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DHAUZ_Api.Controllers
{
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext dbContext;

        public MoviesController(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/[controller]/GetAll")]
        public OkObjectResult GetAll()
        {
            return Ok(MoviesService.GetAll(dbContext));
        }

        [HttpGet]
        [Route("api/[controller]/GetById")]
        public OkObjectResult GetById(int ID)
        {
            return Ok(MoviesService.GetById(dbContext, ID));
        }

        [HttpGet]
        [Route("api/[controller]/GetByIdImdb")]
        public OkObjectResult GetByIdImdb(string IDIMDB)
        {
            return Ok(MoviesService.GetByIdImdb(dbContext, IDIMDB));
        }

        [HttpPost]
        [Route("api/[controller]/Post")]
        public OkObjectResult Post(string IDIMDB)
        {
            return Ok(MoviesService.Save(dbContext, IDIMDB));
        }

        [HttpPut]
        [Route("api/[controller]/Put")]
        public OkObjectResult Put(MovieVM model)
        {
            return Ok(MoviesService.Update(dbContext, model));
        }

        [HttpDelete]
        [Route("api/[controller]/Delete")]
        public OkObjectResult Delete(int ID)
        {
            return Ok(MoviesService.Delete(dbContext, ID));
        }
    }
}
