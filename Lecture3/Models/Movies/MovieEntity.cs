using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/*
 * Klasa jest modelem danych bazy danych.
 * Powinna zawierać atrybuty związane z konfiduracją danych w tabeli.
 */
namespace Lecture3.Models.Movies;
[Table( "movie")]
public class MovieEntity
{
    [Column(name: "movie_id")] 
    public int Id { get; set; }
    [MaxLength()]
    public string? Title { get; set; }
    public int? Budget { get; set; }
    public string? Overview { get; set; }
    [Column(name: "release_date")]
    public DateOnly? ReleaseDate { get; set; }
}