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

    public bool Delete(int id)
    {
        return _items.Remove(id);
    }

    public bool Update(Product product)
    {
        if (!_items.ContainsKey(product.Id))
            return false;

        // Created zostawiamy jak było (żeby nie zmieniać historii)
        product.Created = _items[product.Id].Created;
        _items[product.Id] = product;
        return true;
    }

    public List<Product> GetAll()
    {
        return _items.Values.OrderBy(p => p.Id).ToList();
    }

    public Product? GetById(int id)
    {
        return _items.TryGetValue(id, out var p) ? p : null;
    }
}