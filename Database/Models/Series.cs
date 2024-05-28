namespace Database.Models;

public class Series : ModeloBase
{
    public string? Portada { get; set; }
    public string? VideoLink { get; set; }
    public int ProductoraId { get; set; }
    public int GeneroId { get; set; } 
    
    public Genero? Genero { get; set; }
    public Productora? Productora { get; set; }
}