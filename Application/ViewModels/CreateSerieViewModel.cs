using ITLAStream.Core.Application.ViewModels.BaseViewModel;
using System.ComponentModel.DataAnnotations;


namespace ITLAStream.Core.Application.ViewModels;

public class CreateSerieViewModel : BViewModel
{
    [Required(ErrorMessage = "Debe colocar la portada de la serie")]
    public string Portada { get; set; }
    [Required(ErrorMessage = "Debe colocar el enlace al video de la serie")]
    public string VideoLink { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una productora")]
    public int ProductoraId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un genero")]
    public int GeneroId { get; set; }

    public List<GeneroViewModel> Genero { get; set; }
    public List<ProducturaViewModel> Productora { get; set; }
}