using Invetory_for_home_WEB_API.ver.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invetory_for_home_WEB_API.ver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {

        private InventoryForHomeContext _context;

        //COnstructor o funciono de incializacion que instancie el db context
        public InventarioController(InventoryForHomeContext inventoryForHomeContext)
        {
            _context = inventoryForHomeContext;
        }


        // GET: api/<InventarioController>
        [HttpGet]
        [Route("ReadInvs")]
        public JsonResult ReadInvs()
        {
            var QrysResult = _context.Items.ToList();
            var query = from item in _context.Items
                        join typePrioritary in _context.CatTypePrioritaries
                            on item.IdTypePrioritary equals typePrioritary.IdTypePrioritary
                        join typeStock in _context.CatTypeStocks
                            on item.IdTypeStock equals typeStock.IdTypeStock
                        where item.Active == true
                        select new StoredProcedure1
                        {
                            IdItem = item.IdItem,
                            ItemName = item.ItemName,
                            Stock = item.Stock,
                            TypePrioritaryName = typePrioritary.TypePrioritaryName,
                            TypeStockName = typeStock.TypeStockName,
                            PurchesDate = item.PurchesDate,
                            ExpirationDate = item.ExpirationDate
                        };

            var result = query.ToList(); // Retorna el primer resultado o null si no lo encuentra

            // Devolver la respuesta con el nuevo Item y su relación con CatTypeStock
            return new JsonResult(new { Success = true, Data = result });
        }

        // GET api/<InventarioController>/5
        [HttpGet]
        [Route("ReadInvById/{id}")]
        public JsonResult ReadInvById(int id)
        {
            var QrysResult = _context.Items.Find(id);
            if (QrysResult == null)
            {
                // Devolver la respuesta con el nuevo Item y su relación con CatTypeStock
                return new JsonResult(new { Success = false, Data = QrysResult });
            }
            return new JsonResult(new { Success = true, Data = QrysResult });
        }

        // POST api/<InventarioController>
        [HttpPost]
        [Route("CrearInv/nuevoItem")]
        public JsonResult CrearInv([FromBody] Item nuevoItem)
        {

            Item nuevoArt = new()
            {
                IdItem = 0,  // Se asigna automáticamente al guardar
                ItemName = nuevoItem.ItemName,  // Utilizamos el nombre del ítem como el nombre del stock
                Stock = nuevoItem.Stock,
                IdTypePrioritary = nuevoItem.IdTypePrioritary,
                //TypePrioritaryName = nuevoItem.TypePrioritaryName,
                IdTypeStock = nuevoItem.IdTypeStock,
                //TypeStockName = nuevoItem.TypeStockName,
                PurchesDate = nuevoItem.PurchesDate,
                ExpirationDate = nuevoItem.ExpirationDate,
                Active = nuevoItem.Active  // Utilizamos el estado activo del ítem
            };

            // Guardar el nuevo Item en la base de datos
            _context.Items.Add(nuevoItem);
            _context.SaveChanges();

            //Crear objeto de regreso:

            var query = from item in _context.Items
                        join typePrioritary in _context.CatTypePrioritaries
                            on item.IdTypePrioritary equals typePrioritary.IdTypePrioritary
                        join typeStock in _context.CatTypeStocks
                            on item.IdTypeStock equals typeStock.IdTypeStock
                        where item.Active == true && item.IdItem == nuevoItem.IdItem
                        select new StoredProcedure1
                        {
                            IdItem = item.IdItem,
                            ItemName = item.ItemName,
                            Stock = item.Stock,
                            TypePrioritaryName = typePrioritary.TypePrioritaryName,
                            TypeStockName = typeStock.TypeStockName,
                            PurchesDate = item.PurchesDate,
                            ExpirationDate = item.ExpirationDate
                        };

            var result = query.FirstOrDefault(); // Retorna el primer resultado o null si no lo encuentra

            // Devolver la respuesta con el nuevo Item y su relación con CatTypeStock
            return new JsonResult(new { Success = true, Data = result });
        }

        // PUT api/<InventarioController>/5
        [HttpPost]
        [Route("EditarInv/actItem")]
        public JsonResult EditarInv([FromBody] Item actItem)
        {

            Item editarArt = new()
            {
                IdItem = actItem.IdItem,  // Se asigna automáticamente al guardar
                ItemName = actItem.ItemName,  // Utilizamos el nombre del ítem como el nombre del stock
                Stock = actItem.Stock,
                IdTypePrioritary = actItem.IdTypePrioritary,
                //TypePrioritaryName = nuevoItem.TypePrioritaryName,
                IdTypeStock = actItem.IdTypeStock,
                //TypeStockName = nuevoItem.TypeStockName,
                PurchesDate = actItem.PurchesDate,
                ExpirationDate = actItem.ExpirationDate,
                Active = actItem.Active  // Utilizamos el estado activo del ítem
            };

            // Guardar el nuevo Item en la base de datos
            _context.Items.Update(editarArt);
            _context.SaveChanges();

            // Devolver la respuesta con el nuevo Item y su relación con CatTypeStock
            return new JsonResult(new { Success = true, Data = editarArt });
        }

        // DELETE api/<InventarioController>/5
        [HttpDelete]
        [Route("DeleteArt/{id}")]
        public JsonResult DeleteArt(int id)
        {
            //Obtener el elemento
            var QrysResult = _context.Items.Find(id);
            //Validar que existe
            if (QrysResult != null)
            {
                //eliminar el elemento
                _context.Items.Remove(QrysResult);
                //salvar cambios
                _context.SaveChanges();
                // Devolver ok
                return new JsonResult(new { Success = true, Data = string.Empty });
            }
            else
            {
                return new JsonResult(new { Success = false, Data = "Error: El elemento a borrar no existe." });
            }
        }
    }
}
