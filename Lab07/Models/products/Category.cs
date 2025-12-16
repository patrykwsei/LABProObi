using System.ComponentModel.DataAnnotations;

namespace Lab07.Models.products;

public enum Category
{
    [Display(Name = "Spożywcze")] Food = 1,
    [Display(Name = "Chemia")] Chemistry = 2,
    [Display(Name = "Elektronika")] Electronics = 3,
    [Display(Name = "Inne")] Other = 4
}