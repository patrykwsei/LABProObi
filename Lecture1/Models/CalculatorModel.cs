using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lecture1.Models;

public class CalculatorModel
{
    [Required]
    public double? X { get; set; }
    
    [Required]
    public double? Y { get; set; }
    
    [Required]
    public Operators? Operator { get; set; }
}