namespace Biblioteca.Models
{
    public class Paquete
    {
        public int ID { get; set; }
        public string NombreCLiente { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Entregado { get; set; }
        public bool EsFragil { get; set; }
        public int TamanioPaqueteId { get; set; }
        public TamanioPaquete? TamanioPaquete { get; set; }
        public int BarrioId { get; set; }
        public Barrio? Barrio { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
