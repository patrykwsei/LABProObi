using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab07.models.products
{
    public class Producer
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę producenta")]
        [StringLength(80)]
        public string Name { get; set; } = "";

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}