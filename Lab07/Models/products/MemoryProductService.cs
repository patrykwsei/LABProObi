namespace Lab07.Models.products;

public class MemoryProductService : IProductService
{
    private readonly IDateTimeProvider _timeProvider;

    private readonly Dictionary<int, Product> _products = new();
    private readonly Dictionary<int, string> _producers = new();

    private int _productId = 0;
    private int _producerId = 0;

    public MemoryProductService(IDateTimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public List<Product> FindAll()
    {
        return _products.Values
            .OrderBy(p => p.Id)
            .Select(CloneWithProducerName)
            .ToList();
    }

    public Product? FindById(int id)
    {
        if (!_products.TryGetValue(id, out var p)) return null;
        return CloneWithProducerName(p);
    }

    public int Add(Product model)
    {
        var producerId = GetOrCreateProducerIdByName(model.ProducerName);

        var p = new Product
        {
            Id = ++_productId,
            Name = model.Name,
            Price = model.Price,
            ProductionDate = model.ProductionDate,
            Description = model.Description,
            Category = model.Category,
            ProducerId = producerId,
            ProducerName = _producers[producerId],
            Created = _timeProvider.Now()
        };

        _products[p.Id] = p;
        return p.Id;
    }

    public void Update(Product model)
    {
        if (!_products.ContainsKey(model.Id)) return;

        var producerId = GetOrCreateProducerIdByName(model.ProducerName);

        var p = _products[model.Id];
        p.Name = model.Name;
        p.Price = model.Price;
        p.ProductionDate = model.ProductionDate;
        p.Description = model.Description;
        p.Category = model.Category;
        p.ProducerId = producerId;
        p.ProducerName = _producers[producerId];

        _products[model.Id] = p;
    }

    public void Delete(int id)
    {
        _products.Remove(id);
    }

    public List<(int Id, string Name)> FindAllProducers()
    {
        return _producers
            .OrderBy(kv => kv.Value)
            .Select(kv => (kv.Key, kv.Value))
            .ToList();
    }

    private int GetOrCreateProducerIdByName(string? name)
    {
        name = (name ?? "").Trim();
        if (string.IsNullOrWhiteSpace(name)) name = "Nieznany";

        var existing = _producers.FirstOrDefault(x => x.Value == name);
        if (!existing.Equals(default(KeyValuePair<int, string>)) && existing.Key != 0)
            return existing.Key;

        var id = ++_producerId;
        _producers[id] = name;
        return id;
    }

    private Product CloneWithProducerName(Product p)
    {
        return new Product
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            ProductionDate = p.ProductionDate,
            Description = p.Description,
            Category = p.Category,
            ProducerId = p.ProducerId,
            ProducerName = _producers.TryGetValue(p.ProducerId, out var n) ? n : "",
            Created = p.Created
        };
    }
}
