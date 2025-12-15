using Lab07.Models.products;
using Microsoft.AspNetCore.Mvc;



namespace Lab07.Controllers;

public class ProductsController : Controller
{
    private static Dictionary<int, Product> _products = new();

    public IActionResult Index()
    {
        return View(_products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product model)
    {
        if (!ModelState.IsValid)
            return View(model);

        int id = _products.Count == 0 ? 1 : _products.Keys.Max() + 1;
        model.Id = id;
        _products.Add(id, model);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        if (!_products.ContainsKey(id))
            return NotFound();

        return View(_products[id]);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        if (!_products.ContainsKey(id))
            return NotFound();

        return View(_products[id]);
    }

    [HttpPost]
    public IActionResult Edit(Product model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _products[model.Id] = model;
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        if (!_products.ContainsKey(id))
            return NotFound();

        return View(_products[id]);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        _products.Remove(id);
        return RedirectToAction(nameof(Index));
    }
}