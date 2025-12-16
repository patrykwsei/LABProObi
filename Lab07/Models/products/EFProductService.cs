using Data;
using Lab07.Mappers;

namespace Lab07.Models.products;

public class EFProductService : IProductService
{
    private readonly AppDbContext _context;

    public EFProductService(AppDbContext context)
    {
        _context = context;
    }

    public int Add(Product product)
    {
        var entity = ProductMapper.ToEntity(product);
        _context.Products.Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public void Delete(int id)
    {
        var entity = _context.Products.Find(id);
        if (entity != null)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }
    }

    public List<Product> FindAll()
    {
        return _context.Products
            .Select(ProductMapper.FromEntity)
            .ToList();
    }

    public Product? FindById(int id)
    {
        var entity = _context.Products.Find(id);
        return entity == null ? null : ProductMapper.FromEntity(entity);
    }

    public void Update(Product product)
    {
        _context.Products.Update(ProductMapper.ToEntity(product));
        _context.SaveChanges();
    }
}