using System.Diagnostics;
using Application.Services;
using Application.Utils;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITLAStream.Controllers;

public class HomeController : Controller
{
    private readonly ProductoraService _productoraService;
    private readonly GeneroService _generoService;
    private readonly SerieService _serieService;

    public HomeController(ProductoraService productoraService, GeneroService generoService, SerieService serieService)
    {
        _generoService = generoService;
        _productoraService = productoraService;
        _serieService = serieService;
    }

    public async Task<IActionResult> Index(FiltroViewModel vm, string nombre)
    {
        ViewBag.genero = await _generoService.GetAll();
        ViewBag.productora = await _productoraService.GetAll();
        List<SerieViewModel> series = await _serieService.GetAll();
        if (vm.GeneroId != 0)
        {
            series = await _serieService.GetAllFilters(vm);
        }

        if(vm.ProductoraId != 0)
        {
            series = await _serieService.GetAllFilters(vm);
        }

        if (nombre != null)
        {
            series = await _serieService.GetByName(nombre);
        }

        if(vm.GeneroId == 0 && vm.ProductoraId == 0 && vm.Nombre == null)
        {
            series = await _serieService.GetAll();
        }

        return View(series);
    }


    public async Task<ActionResult> Reproductor(int serieId)
    {

        var vm = await _serieService.GetById(serieId);
        vm.VideoLink = ConverterVideo.Convertir(vm.VideoLink);
        return View(vm);
    }

}