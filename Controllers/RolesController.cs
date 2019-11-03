

using System.Linq;
using System.Threading.Tasks;
using Crud_json.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud_json.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        [HttpPost]
        public async Task <ActionResult<RolesModel>> aPost(RolesModel payload)
        {
            using (var rc = new RolesContext()){
                rc.Rolmc.Add(payload);
                await rc.SaveChangesAsync();
            }
            return Ok(payload);
        }
        [HttpGet("{id?}")]
        public async Task <ActionResult<RolesModel>> aGet(int? id)
        {
            using (var rc = new RolesContext()){
                if (id==null){
                    var roles = rc.Rolmc.ToList();
                    return Ok(roles);
                }
               var aw =await rc.Rolmc.FindAsync(id);
               /*Buscar que rayos hace esto xd*/
               return NotFound(aw);
            }
            
        }
        [HttpPut("{id}")]
        public async Task <ActionResult<RolesModel>> aPut(int id,[FromBody]RolesModel payload)
        {
            using (var rc = new RolesContext())
            {
                    var aw = await rc.Rolmc.FindAsync(id);

                    if(aw == null)
                    {
                        return BadRequest("id not found");
                    }   /* Selecciona la "lista" del id (parametros del id) */
                    aw.nombrerol = payload.nombrerol;
                    rc.Update(aw);
                    await rc.SaveChangesAsync();
                    return Ok(aw);
            }
        }
        [HttpDelete("{id}")]

        public async Task <ActionResult<RolesModel>> aDel(int id)
        {
            using (var rc = new RolesContext())
                {
                    var aw = await rc.Rolmc.FindAsync(id);
                    if (aw == null)
                    {
                        return NotFound();
                    }
                    rc.Rolmc.Remove(aw);
                    await rc.SaveChangesAsync();
                    return Ok(aw);
                }
        }

    }
}