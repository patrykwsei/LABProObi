using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("products")]
public class ProductEntity
{
    public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = "";

    [Required]
    public decimal Price { get; set; }

    public int ProducerId { get; set; }
    public ProducerEntity? Producer { get; set; }

    public DateTime ProductionDate { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public int Category { get; set; }

    public DateTime Created { get; set; }
}