using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITLAStream.Controllers;

public class SeriesController : Controller
{
    private readonly SerieService _serieService;
    private readonly GeneroService _generoService;
    private readonly ProductoraService _productoraService;

    public SeriesController(SerieService serieService, GeneroService generoService, ProductoraService productoraService)
    {
        _serieService = serieService;
        _generoService = generoService;
        _productoraService = productoraService;

    }

    // Vista general de los generos
    public async Task<ActionResult> Series()
    {
        var series = await _serieService.GetAll();
        return View(series);
    }


    // Pagina para crear un nuevo genero o actualizar uno existente
    [HttpGet]
    public async Task<ActionResult> Create(int idSerie)
    {
        ViewBag.generoSerie = await _generoService.GetAll();
        ViewBag.productoraSerie = await _productoraService.GetAll();

        CreateSerieViewModel vm = new();

        if (idSerie != 0)
        {
            vm = await _serieService.GetById(idSerie);
        }
        return View(vm);
    }


    [HttpPost]
    public async Task<ActionResult> Create(CreateSerieViewModel vm)
    {
        if (vm.Id == 0)
        {
            await _serieService.Add(vm);
        }
        else
        {
            await _serieService.Update(vm);
        }

        return RedirectToRoute(new { Controller = "Series", Action = "Series" });
    }


    // Pagina para eliminar un genero
    public async Task<ActionResult> Delete(int idSerie)
    {
        await _serieService.Delete(idSerie);
        return RedirectToAction("Series");
    }
}