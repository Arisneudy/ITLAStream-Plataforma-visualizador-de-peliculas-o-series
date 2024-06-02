using ITLAStream.Core.Application.Interfaces.Services;
using ITLAStream.Core.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITLAStream.Controllers;

public class ProductoraController : Controller
{
    private readonly IProductoraService _productoraService;

    public ProductoraController(IProductoraService productoraService)
    {
        _productoraService = productoraService;
    }

    // Vista general de las productoras
    public async Task<ActionResult> Productora()
    {
        var generos = await _productoraService.GetAll();

        return View(generos);
    }


    // Pagina para crear un nueva productora o actualizar una existente
    [HttpGet]
    public async Task<ActionResult> Create(int idProductora)
    {
        CreateProductoraViewModel vm = new();

        if (idProductora != 0)
        {
            vm = await _productoraService.GetById(idProductora);
        }
        return View(vm);
    }


    [HttpPost]
    public async Task<ActionResult> Create(CreateProductoraViewModel vm)
    {
        if (vm.Id == 0)
        {
            await _productoraService.Add(vm);
        }
        else
        {
            await _productoraService.Update(vm);
        }

        return RedirectToRoute(new { Controller = "Productora", Action = "Productora" });
    }


    // Pagina para eliminar una productora
    public async Task<ActionResult> Delete(int idProductora)
    {
        await _productoraService.Delete(idProductora);
        return RedirectToAction("Productora");
    }
}