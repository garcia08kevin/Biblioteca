namespace Biblioteca.Models
{
    public class Barrio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int CuidadId { get; set; }
        public Cuidad? Cuidad { get; set; }
    }
}
