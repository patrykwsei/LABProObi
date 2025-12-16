using System.Collections.Generic;

namespace Lab07.Models.products;

public interface IProductService
{
    int Add(Product product);
    bool Delete(int id);
    bool Update(Product product);
    List<Product> GetAll();
    Product? GetById(int id);
}