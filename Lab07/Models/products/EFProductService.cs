using Data;
using Data.Entities;
using Lab07.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Lab07.Models.products;

public class EFProductService : IProductService
{
    private readonly AppDbContext _context;
    private readonly IDateTimeProvider _timeProvider;

    public EFProductService(AppDbContext context, IDateTimeProvider timeProvider)
    {
        _context = context;
        _timeProvider = timeProvider;
    }

    public List<Product> FindAll()
    {
        return _context.Products
            .Include(p => p.Producer)
            .OrderBy(p => p.Id)
            .Select(p => ProductMapper.FromEntity(p))
            .ToList();
    }

    public Product? FindById(int id)
    {
        var entity = _context.Products
            .Include(p => p.Producer)
            .FirstOrDefault(p => p.Id == id);

        return entity == null ? null : ProductMapper.FromEntity(entity);
    }

    public int Add(Product model)
    {
        var producer = GetOrCreateProducer(model.ProducerName);

        var entity = ProductMapper.ToEntity(model);
        entity.ProducerId = producer.Id;
        entity.Created = _timeProvider.Now(); 

        _context.Products.Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public void Update(Product model)
    {
        var existing = _context.Products.FirstOrDefault(p => p.Id == model.Id);
        if (existing == null) return;

        var producer = GetOrCreateProducer(model.ProducerName);

        existing.Name = model.Name;
        existing.Price = model.Price;
        existing.ProductionDate = model.ProductionDate;
        existing.Description = model.Description;
        existing.Category = (int)model.Category;
        existing.ProducerId = producer.Id;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var existing = _context.Products.FirstOrDefault(p => p.Id == id);
        if (existing == null) return;

        _context.Products.Remove(existing);
        _context.SaveChanges();
    }

    public List<(int Id, string Name)> FindAllProducers()
    {
        return _context.Producers
            .OrderBy(p => p.Name)
            .Select(p => new ValueTuple<int, string>(p.Id, p.Name))
            .ToList();
    }

    private ProducerEntity GetOrCreateProducer(string? name)
    {
        name = (name ?? "").Trim();
        if (string.IsNullOrWhiteSpace(name)) name = "Nieznany";

        var existing = _context.Producers.FirstOrDefault(p => p.Name == name);
        if (existing != null) return existing;

        var created = new ProducerEntity { Name = name };
        _context.Producers.Add(created);
        _context.SaveChanges();
        return created;
    }
}
