using System.Collections.Generic;
using System.Linq;

namespace Lab07.Models.products;

public class MemoryProductService : IProductService
{
    private readonly IDateTimeProvider _timeProvider;
    private readonly Dictionary<int, Product> _items = new();
    private int _id = 0;

    public MemoryProductService(IDateTimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public int Add(Product product)
    {
        product.Id = ++_id;
        product.Created = _timeProvider.Now();
        _items[product.Id] = product;
        return product.Id;
    }

    public void Delete(int id)
    {
        _items.Remove(id);
    }

    public void Update(Product product)
    {
        if (_items.ContainsKey(product.Id))
            _items[product.Id] = product;
    }

    public List<Product> FindAll()
    {
        return _items.Values.ToList();
    }

    public Product? FindById(int id)
    {
        return _items.TryGetValue(id, out var p) ? p : null;
    }
}