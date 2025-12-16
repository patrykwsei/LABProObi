using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("producers")]
public class ProducerEntity
{
    public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = "";

    public ISet<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}