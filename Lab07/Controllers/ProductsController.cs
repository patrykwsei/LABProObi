using Lab07.Models.products;
using Microsoft.AspNetCore.Mvc;

namespace Lab07.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View(_service.FindAll());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Product());
    }

    [HttpPost]
    public IActionResult Create(Product model)
    {
        if (!ModelState.IsValid) return View(model);

        _service.Add(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var p = _service.FindById(id);
        if (p == null) return NotFound();
        return View(p);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var p = _service.FindById(id);
        if (p == null) return NotFound();
        return View(p);
    }

    [HttpPost]
    public IActionResult Edit(Product model)
    {
        if (!ModelState.IsValid) return View(model);

        _service.Update(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var p = _service.FindById(id);
        if (p == null) return NotFound();
        return View(p);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        _service.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}