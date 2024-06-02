using ITLAStream.Core.Domain.Entities;
using ITLAStream.Core.Application.ViewModels.BaseViewModel;


namespace ITLAStream.Core.Application.ViewModels;

public class SerieViewModel : BViewModel
{
    public string Portada { get; set; }
    public string VideoLink { get; set; }
    public int ProductoraId { get; set; }
    public int GeneroId { get; set; }


    public Genero Genero { get; set; }
    public Productora Productora { get; set; }
}