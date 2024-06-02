using System.ComponentModel.DataAnnotations;

namespace ITLAStream.Core.Application.ViewModels.BaseViewModel;

public class BViewModel
{
    public virtual int Id { get; set; }
    [Required(ErrorMessage = "Debe colocar el nombre")]
    public virtual string Nombre { get; set; }
    public virtual string Descripcion { get; set; }
}