using System.ComponentModel.DataAnnotations;

namespace Lecture2.Models;

// Typ wyliczeniowy może służyć do tworzenia listy kategorii książek
// Atrybuty Display określają nazwy wyświetlane w widoku
// np. w elemencie HTML typu select.
public enum Category
{
    [Display(Name = "Nauka")]
    Science, 
    [Display(Name = "Technologia")]
    Technology,
    [Display(Name = "Programowanie")]
    Programming,
    [Display(Name = "Informatyka")]
    Engineering,
    [Display(Name = "Historia")]
    History,
    [Display(Name = "Medycyna")]
    Medical,
    [Display(Name = "Dramat")]
    Drama,
    [Display(Name = "Komedia")]
    Comedy,
    [Display(Name = "Romans")]
    Romance,
    [Display(Name = "Akcja")]
    Action,
    [Display(Name = "Przygoda")]
    Adventure,
    [Display(Name = "Fantasy")]
    Fantasy,
    [Display(Name = "Sci-Fi")]
    SciFi,
    [Display(Name = "Horror")]
    Horror,
    [Display(Name = "Tajemnica")]
    Mystery,
    [Display(Name = "Kryminał")]
    Crime,
}