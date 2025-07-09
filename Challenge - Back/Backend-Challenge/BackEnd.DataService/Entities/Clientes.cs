namespace BackEnd.DataService.Entities
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateOnly? Fecha_Nacimiento { get; set; }
        public string CUIT {  get; set; }
        public string? Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
