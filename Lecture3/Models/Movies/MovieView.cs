using System.ComponentModel.DataAnnotations;
/*
 * Klasa jest modelem widoku i zawiera konfigurację np. fomratowania liczb, daty
 * Atrybutem Display wskazujemy poprawne nazwy np. zamiast "RealeaseDate" używamy poprawnej formy "Release Date"
 * Metody ToEntity i FromEntity pozwalają łatwo przenieść dane z modelu widoku do modelu danych.
 */
namespace Lecture3.Models.Movies;
[Display(Name = "Movie")]
public class MovieView
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    public int? Budget { get; set; }
    public string? Overview { get; set; }
    
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateOnly? ReleaseDate { get; set; }

    public MovieEntity ToEntity()
    {
        return new MovieEntity()
        {
            Id = Id,
            Title = Title,
            Budget = Budget,
            Overview = Overview,
            ReleaseDate = ReleaseDate
        };
    }

    public static MovieView FromEntity(MovieEntity entity)
    {
        return new MovieView()
        {
            Id = entity.Id,
            Title = entity.Title,
            Budget = entity.Budget,
            Overview = entity.Overview,
            ReleaseDate = entity.ReleaseDate
        };
    }
}