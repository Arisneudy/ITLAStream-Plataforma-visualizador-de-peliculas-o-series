using ITLAStream.Core.Application.Interfaces.Services;
using ITLAStream.Core.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITLAStream.Controllers;

public class SeriesController : Controller
{
    private readonly IProductoraService _productoraService;
    private readonly IGeneroService _generoService;
    private readonly ISerieService _serieService;


    public SeriesController(ISerieService serieService, IGeneroService generoService, IProductoraService productoraService)
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