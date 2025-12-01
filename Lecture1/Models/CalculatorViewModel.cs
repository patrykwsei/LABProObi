using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lecture1.Models;

public class CalculatorViewModel
{
    private static Dictionary<Operators, string> _symbols = new()
        {
            { Operators.Add, "+"},
            { Operators.Sub, "−"},
            { Operators.Mul, "×"},
            { Operators.Div, "÷"}
        };
    [Required]
    public double X { get; init; }
    [Required]
    public double Y { get; init; }
    [Required(ErrorMessage = "Nie wybrano operatora")]
    public Operators Operator { get; set; }
    public double? Result { get; set; }
    
    public List<SelectListItem> OperatorEntities => _symbols.Select(item => new SelectListItem()
    {
        Value = item.Key.ToString(),
        Text = item.Value
    }).ToList();
    
    public string View => Result is not null ? $"{X} {_symbols[Operator]} {Y} = {Result}" : "Błąd obliczeń";
    
    public static CalculatorViewModel WithoutResult(CalculatorModel model)
    {
        return new CalculatorViewModel()
        {
            X = model.X??0,
            Y = model.Y??0,
            Result = null,
            Operator = model.Operator??Operators.Add
        };
    }
    
    public static CalculatorViewModel WithResult(CalculatorModel model, double result)
    {
        return new CalculatorViewModel()
        {
            X = model.X??0,
            Y = model.Y??0,
            Result = result,
            Operator = model.Operator??Operators.Add
        };
    }
}