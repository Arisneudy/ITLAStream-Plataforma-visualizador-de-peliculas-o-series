using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITLAStream.Controllers;

public class GeneroController : Controller
{

    private readonly GeneroService _generoService;
    
    public GeneroController(GeneroService generoService)
    {
        _generoService = generoService;
    }
    
    // Vista general de los generos
    public async Task<ActionResult> Genero()
    {
        var generos = await _generoService.GetAll();
        
        return View(generos);
    }


    // Pagina para crear un nuevo genero o actualizar uno existente
    [HttpGet]
    public async Task<ActionResult> Create(int idGenero)
    {
        CreateGeneroViewModel vm = new();

        if (idGenero != 0)
        {
            vm = await _generoService.GetById(idGenero);
        }
        return View(vm);
    }


    [HttpPost]
    public async Task<ActionResult> Create(CreateGeneroViewModel vm)
    {
        if (vm.Id == 0)
        {
            await _generoService.Add(vm);
        }
        else
        {
            await _generoService.Update(vm);
        }

        return RedirectToRoute(new { Controller = "Genero", Action = "Genero" });
    }


    // Pagina para eliminar un genero
    public async Task<ActionResult> Delete(int idGenero)
    {
        await _generoService.Delete(idGenero);
        return RedirectToAction("Genero");
    }
}