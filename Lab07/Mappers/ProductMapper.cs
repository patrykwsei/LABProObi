using Data.Entities;
using Lab07.Models.products;

namespace Lab07.Mappers;

public static class ProductMapper
{
    public static Product FromEntity(ProductEntity e)
    {
        return new Product
        {
            Id = e.Id,
            Name = e.Name,
            Price = e.Price,
            ProducerId = e.ProducerId,
            ProducerName = e.Producer?.Name ?? "",
            ProductionDate = e.ProductionDate,
            Description = e.Description,
            Category = (ProductCategory)e.Category,
            Created = e.Created
        };
    }

    public static ProductEntity ToEntity(Product m)
    {
        return new ProductEntity
        {
            Id = m.Id,
            Name = m.Name,
            Price = m.Price,
            ProducerId = m.ProducerId,
            ProductionDate = m.ProductionDate,
            Description = m.Description,
            Category = (int)m.Category,
            Created = m.Created
        };
    }
}