using Application.ViewModels;
using Application.ViewModels.BaseViewModel;

namespace ITLAStream.Core.Application.ViewModels;

public class CreateSerieViewModel : BViewModel
{
    public string Portada { get; set; }
    public string VideoLink { get; set; }
    public int ProductoraId { get; set; }
    public int GeneroId { get; set; }

    public List<GeneroViewModel> Genero { get; set; }
    public List<ProducturaViewModel> Productora { get; set; }
}