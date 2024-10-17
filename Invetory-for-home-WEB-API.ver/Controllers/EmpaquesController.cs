using Invetory_for_home_WEB_API.ver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invetory_for_home_WEB_API.ver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpaquesController : ControllerBase
    {
        //Tiene que tener una instancia privada del db context
        private InventoryForHomeContext _context;

        //COnstructor o funciono de incializacion que instancie el db context
        public EmpaquesController(InventoryForHomeContext inventoryForHomeContext)
        {
            _context = inventoryForHomeContext;
        }

        // GET: api/<EmpaquesController>
        [HttpGet]
        [Route("ReadEmps")]
        public JsonResult ReadEmps()
        {
            var QryResult = _context.CatTypeStocks.ToList();
            return new JsonResult(new { Success = true, Data = QryResult });
        }

        // GET api/<EmpaquesController>/5
        [HttpGet]
        [Route("ReadEmpById/{id}")]
        public JsonResult ReadEmpById(int id)
        {
            var QryResult = _context.CatTypeStocks.Find(id);
            return new JsonResult(new { Success = true, Data = QryResult });
        }

        // POST api/<EmpaquesController>
        [HttpPost]
        [Route("CrearEmp/nombreEmpaque")]
        public JsonResult CrearEmp(string nombreEmpaque)
        {
            CatTypeStock nuevoEmpaque = new()
            {
                IdTypeStock = 0,
                TypeStockName = nombreEmpaque,
                Active = true,
            };

            _context.CatTypeStocks.Add(nuevoEmpaque);
            _context.SaveChanges();
            return new JsonResult(new { Success = true, Data = nuevoEmpaque });
        }

        [HttpPost]
        [Route("EditEmp/nuevoItem")]
        public JsonResult EditEmp(int id, [FromBody] CatTypeStock nuevoItem)
        {
            CatTypeStock editarItem = new()
            {
                IdTypeStock = nuevoItem.IdTypeStock,
                TypeStockName = nuevoItem.TypeStockName,
                Active = true,
            };

            _context.CatTypeStocks.Update(editarItem);
            _context.SaveChanges();
            return new JsonResult(new { Success = true, Data = editarItem });
        }

        // DELETE api/<EmpaquesController>/5
        [HttpDelete]
        [Route("DelEmpById/{id}")]
        public JsonResult Delete(int id)
        {
            //Obtener el elemento
            var QryResult = _context.CatTypeStocks.Find(id);
            //Validar que existe
            if (QryResult != null)
            {
                //Eliminar el elemento de la tabla
                _context.CatTypeStocks.Remove(QryResult);
                //Guardar cambios
                _context.SaveChanges();
                //Rregresar ok
                return new JsonResult(new { Success = true, Data = string.Empty });
            }
            else
            {
                return new JsonResult(new { Success = false, Data = "Error: El elemento a borrar no existe." });
            }
        }
    }
}
