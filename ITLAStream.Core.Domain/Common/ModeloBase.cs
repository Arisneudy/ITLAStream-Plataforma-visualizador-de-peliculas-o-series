using System.ComponentModel.DataAnnotations;

namespace ITLAStream.Core.Domain.Common;

public class ModeloBase
{
    public virtual int Id { get; set; }
    [Required]
    public virtual string Nombre { get; set; }
    public virtual string? Descripcion { get; set; }
}