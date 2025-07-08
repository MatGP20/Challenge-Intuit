namespace Backend_Challenge.Clients
{
    public class ClientesModel
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
