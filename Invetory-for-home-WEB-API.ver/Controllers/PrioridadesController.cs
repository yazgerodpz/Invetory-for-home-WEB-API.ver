using Invetory_for_home_WEB_API.ver.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invetory_for_home_WEB_API.ver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadesController : ControllerBase
    {
        //Tiene que tener una instancia privada del db context
        private InventoryForHomeContext _context;

        //COnstructor o funciono de incializacion que instancie el db context
        public PrioridadesController(InventoryForHomeContext inventoryForHomeContext)
        {
            _context = inventoryForHomeContext;
        }
        // GET: api/<PrioridadesController>
        [HttpGet]
        [Route("ReadPrios")]
        public JsonResult ReadPrios()
        {
            var QrysResult = _context.CatTypePrioritaries.ToList();
            return new JsonResult(new { Success = true, Data = QrysResult });
        }

        // GET api/<PrioridadesController>/5
        [HttpGet]
        [Route("ReadPriosById/{id}")]
        public JsonResult ReadPrioById(int id)
        {
            var QrysResult = _context.CatTypePrioritaries.Find(id);
            return new JsonResult(new { Success = true, Data = QrysResult });
        }

        // POST api/<PrioridadesController>
        [HttpPost]
        [Route("CrearPrios/nuevoReglaPrio")]
        public JsonResult CrearPrio([FromBody] CatTypePrioritary nuevoReglaPrio)
        {
            CatTypePrioritary nuevoReglaPriority = new()
            {
                IdTypePrioritary = 0,  // Asigna un ID nuevo si es necesario.
                TypePrioritaryName = nuevoReglaPrio.TypePrioritaryName,  // Utiliza el nombre del objeto recibido.
                _Description = nuevoReglaPrio._Description,
                Active = true,  // Utiliza el estado activo del objeto recibido.
            };

            _context.CatTypePrioritaries.Add(nuevoReglaPriority);
            _context.SaveChanges();

            return new JsonResult(new { Success = true, Data = nuevoReglaPriority });
        }

        // PUT api/<PrioridadesController>/5
        [HttpPost]
        [Route("EditPrios/ActReglaPrio")]
        public JsonResult EditPrio(int id, [FromBody] CatTypePrioritary ActReglaPrio)
        {
            CatTypePrioritary editarReglaP = new()
            {
                IdTypePrioritary = ActReglaPrio.IdTypePrioritary,  // Asigna un ID nuevo si es necesario.
                TypePrioritaryName = ActReglaPrio.TypePrioritaryName,  // Utiliza el nombre del objeto recibido.
                _Description = ActReglaPrio._Description,
                Active = true,  // Utiliza el estado activo del objeto recibido.
            };

            _context.CatTypePrioritaries.Update(editarReglaP);
            _context.SaveChanges();

            return new JsonResult(new { Success = true, Data = editarReglaP });
        }

        // DELETE api/<PrioridadesController>/5
        [HttpDelete]

        public void Delete(int id)
        {
        }
    }
}
