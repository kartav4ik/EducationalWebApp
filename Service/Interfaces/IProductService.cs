using AppDomain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain.Models;

namespace Service.Interfaces
{
    public interface IProductService
    {
        Task<IBaseResponse<IEnumerable<Product>>> GetProducts();
        Task<IBaseResponse<Product>> GetProduct(Guid id);
        Task<IBaseResponse<Product>> AddProduct(Product newProduct);
        Task<IBaseResponse<Product>> EditProduct(Guid id, Product updProduct);
        Task<IBaseResponse<bool>> DeleteProduct(Guid id);
    }
}
