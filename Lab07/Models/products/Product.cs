using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Lab07.models.movies;

namespace Lab07.models.products
{
    public class Product
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę produktu")]
        [StringLength(100)]
        public string Name { get; set; } = "";

        [Range(0.01, 100000)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public int ProducerId { get; set; }

        public Producer? Producer { get; set; }
    }
}