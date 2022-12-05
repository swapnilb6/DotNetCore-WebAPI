using System.Collections.Generic;

namespace MyWebAPI2.Repository
{
    public interface IProductRepository
    {
        int AddProduct(ProductModel product);
        List<ProductModel> GetProducts();
    }
}