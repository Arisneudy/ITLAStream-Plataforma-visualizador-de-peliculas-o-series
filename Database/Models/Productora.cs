namespace Database.Models;

public class Productora : ModeloBase
{
    public ICollection<Series> Serie { get; set; }
}