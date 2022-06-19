namespace Biblioteca.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public int Cedula { get; set; }
        public string Direccion { get; set; }
        public string Barrio { get; set; }
        public int CuidadId { get; set; }
        public Cuidad? Cuidad { get; set; }

    }
}
