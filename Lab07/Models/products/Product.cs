using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Lab07.Models.products;

public enum ProductCategory
{
    [Display(Name = "Spożywcze")] Food = 1,
    [Display(Name = "Chemia")] Chemistry = 2,
    [Display(Name = "Elektronika")] Electronics = 3,
    [Display(Name = "Inne")] Other = 4
}

public class Product
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage = "Podaj nazwę.")]
    [StringLength(80)]
    [Display(Name = "Nazwa")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Podaj cenę.")]
    [Range(0.01, 1_000_000, ErrorMessage = "Cena musi być > 0.")]
    [Display(Name = "Cena")]
    public decimal Price { get; set; }

    // FK do bazy (trzymamy, ale użytkownik wpisuje nazwę)
    [HiddenInput]
    [ValidateNever]
    public int ProducerId { get; set; }

    [Required(ErrorMessage = "Wpisz nazwę producenta.")]
    [StringLength(80)]
    [Display(Name = "Producent")]
    public string ProducerName { get; set; } = "";

    [DataType(DataType.Date)]
    [Display(Name = "Data produkcji")]
    public DateTime ProductionDate { get; set; } = DateTime.Today;

    [StringLength(500)]
    [Display(Name = "Opis")]
    public string? Description { get; set; }

    [Display(Name = "Kategoria")]
    public ProductCategory Category { get; set; } = ProductCategory.Other;

    [HiddenInput]
    public DateTime Created { get; set; }
}