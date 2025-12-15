using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace Lab07.Models.products;

public class Product
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage = "Podaj nazwę.")]
    [StringLength(100, ErrorMessage = "Nazwa max 100 znaków.")]
    public string Name { get; set; } = "";

    [Range(0.01, 1000000, ErrorMessage = "Cena musi być > 0.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Podaj producenta.")]
    [StringLength(100)]
    public string Producer { get; set; } = "";

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Podaj datę produkcji.")]
    public DateTime ProductionDate { get; set; } = DateTime.Today;

    [StringLength(500, ErrorMessage = "Opis max 500 znaków.")]
    public string? Description { get; set; }
}