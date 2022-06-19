using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Paquete
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public int NivelFragilidad { get; set; }
        public int? EstadoPaqueteId { get; set; }
        public EstadoPaquete? EstadoPaquete { get; set; }
        public int TamanioPaqueteId { get; set; }
        public TamanioPaquete? TamanioPaquete { get; set; }     
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
