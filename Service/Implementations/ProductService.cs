using AppDomain.Enum;
using AppDomain.Response;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain.Models;
using DataAccess.Interfaces;

namespace Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
        {
            var baseResponse = new BaseResponse<IEnumerable<Product>>();
            try
            {
                var product = await _productRepository.GetAll();
                baseResponse.Data = product;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
             
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = ex.Message
                };
            }
        }
        public async Task<IBaseResponse<Product>> GetProduct(Guid id)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
 
                var product = await _productRepository.Get(id);
                baseResponse.Data = product;                            
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Product>> AddProduct(Product newProduct)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
                var product = await _productRepository.Add(newProduct);
                baseResponse.Data = product;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Product>> EditProduct(Guid id, Product newProduct)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
                var product = await _productRepository.Update(id, newProduct);
                if (product != null)
                {
                    baseResponse.Data = product;
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            
            catch(Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteProduct(Guid id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var productRemoved = await _productRepository.Remove(id);
                baseResponse.Data = productRemoved;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = ex.Message
                };
            }
        }
    }
}
