using API_Service.Context;
using API_Service.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbContext = API_Service.Context.DbContext;

namespace API_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            using (DbContext context = new DbContext())
            {
                var result = context.Set<Gallery>().ToList();
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            

        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(Gallery gallery)
        {
            using (DbContext context = new DbContext())
            {
                var addedEntity = context.Entry(gallery);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                if (addedEntity != null)
                {
                    return Ok();
                }
                return BadRequest();
            }
            
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {

            using (DbContext context = new DbContext())
            {
                var entity = context.Set<Gallery>().FirstOrDefault(x => x.Id == id);
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
                if (deletedEntity != null)
                {
                    return Ok();
                }
                return BadRequest();
            }
           
            
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Gallery gallery)
        {
            using (DbContext context = new DbContext())
            {
                var updatedEntity = context.Entry(gallery);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                if (updatedEntity != null)
                {
                    return Ok();
                }
                return BadRequest();
            }
            
        }
        [HttpPost("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            using (DbContext context = new DbContext())
            {
                var result =  context.Set<Gallery>().FirstOrDefault(x => x.Id == id);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
           
           
        }
    }
}
