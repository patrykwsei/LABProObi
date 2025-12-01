using Lecture1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture1.Controllers;

public class CalculatorController(ILogger<CalculatorController> logger): Controller
{
    public IActionResult Index()
    {
        return View(new CalculatorModel());       
    }
    [HttpGet]
    public IActionResult Result(CalculatorViewModel model)
    {
        logger.LogInformation("Obliczanie: {X} {Op} {Y}", model.X, model.Operator, model.Y);
        if (!ModelState.IsValid)
        {
            model.Result = null;
            return View(model);
        }
        model.Result = Calculator.Calculate(model);
        return View(model);       
    }
}