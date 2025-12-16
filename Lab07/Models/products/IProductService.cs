namespace Lab07.Models.products;

public interface IProductService
{
    int Add(Product product);
    void Update(Product model);
    void Delete(int id);
    List<Product> FindAll();
    Product? FindById(int id);
}