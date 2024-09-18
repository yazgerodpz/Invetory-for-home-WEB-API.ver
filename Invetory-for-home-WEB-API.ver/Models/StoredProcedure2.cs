namespace Invetory_for_home_WEB_API.ver.Models
{
    public class StoredProcedure2
    {
        public int IdTypePrioritary { get; set; }

        public string TypePrioritaryName { get; set; } = null!;

        public string Description { get; set; } = null!;

        //Conversion de objeto a texto para el listbox
        public override string ToString()
        {
            return $"{TypePrioritaryName}: {Description}";
        }
    }
}
