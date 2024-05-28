namespace Database.Models;

public class Genero : ModeloBase
{
    public ICollection<Series> Serie { get; set; }
}