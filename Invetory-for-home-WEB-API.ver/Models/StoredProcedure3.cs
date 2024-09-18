namespace Invetory_for_home_WEB_API.ver.Models
{
    public class StoredProcedure3
    {
        public int IdTypeStock { get; set; }
        public string TypeStockName { get; set; } = null!;


        public override string ToString()
        {
            return $"{TypeStockName}";
        }
    }
}
