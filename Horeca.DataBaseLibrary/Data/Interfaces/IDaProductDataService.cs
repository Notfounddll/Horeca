using Horeca.DataBaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data.Interfaces
{
    public interface IDaProductDataService
    {
        public Task<ProductModel> GetProductById(int Id);
        public Task<List<ProductModel>> GetAllProducts();
        public Task CreateProduct(ProductModel newProduct);
        public Task DeleteProduct(int setActive);
        public Task UpdateProduct(ProductModel updateProduct);
    }
}
