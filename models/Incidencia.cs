namespace ApiMigracion.Models
{
    public class Incidencia
    {
        public int Id { get; set; }
        public required string Pasaporte { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string WhatsApp { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int AgenteId { get; set; }
    }
}
