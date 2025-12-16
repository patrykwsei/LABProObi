using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab07.Models.products;

public class Producer
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage = "Podaj nazwę producenta.")]
    [StringLength(80)]
    [Display(Name = "Nazwa producenta")]
    public string Name { get; set; } = "";
}