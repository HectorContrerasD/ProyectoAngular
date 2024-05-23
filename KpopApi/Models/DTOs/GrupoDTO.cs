namespace KpopApi.Models.DTOs
{
    public class GrupoDTO
    {
        public int? Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Integrantes { get; set; } = null!;
        public DateOnly FechaDebut { get; set; }
        public int CantidadAlbums { get; set; }
        public string? Imagen { get; set; }
     
    }
}
