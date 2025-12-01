using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lecture1.Models;

public enum Operators
{
    [Display(Name = "+")]
    Add, 
    [Display(Name = "−")]
    Sub, 
    [Display(Name = "×")]
    Mul, 
    [Display(Name = "÷")]   
    Div
}