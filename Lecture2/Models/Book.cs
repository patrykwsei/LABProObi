using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lecture2.Models;
// Przykładowa klasa modelu.
// Klasa ta pełni jednocześnie rolę modelu danych jak i modelu widoku.
// W bardzie rozbudowanych aplikacjacg należy tworzyć osobne
// modele: widoku i danych (czasem też osobne klasy encji zapisywanych do bazy).

[Display(Name="Książka")]
public class Book
{
    [HiddenInput]
    public int Id { get; set; }
    [Display(Name="Tytuł")]
    [Required]
    public string Title { get; set; }
    [Display(Name="ISBN")]
    [StringLength(13, MinimumLength = 13)]
    public string ISBN { get; set; }
    [Display(Name="Liczba stron")]
    [Range(10, 10_000)]
    public int Pages { get; set; }
    [Display(Name="Rok wydania")]
    [DisplayFormat(DataFormatString = "{0:D}")]
    [Range(1800, 3000)]
    public int PublishingYear { get; set; }
    [Display(Name="Kategoria")]
    public Category Category { get; set; }
}