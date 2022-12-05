using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI2.Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<ProductModel> productlist = new List<ProductModel>();

        public int AddProduct(ProductModel product)
        {
            product.ProductID = productlist.Count + 1;
            productlist.Add(product);

            return product.ProductID;
        }


        public List<ProductModel> GetProducts()
        {
            return productlist;
        }
    }
}
