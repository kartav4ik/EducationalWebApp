using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain.Enum;
using AppDomain.Models;
using AppDomain.Response;
using DataAccess.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IBaseResponse<Category>> AddCategory(Category newCategory)
        {
            var baseResponse = new BaseResponse<Category>();
            try
            {
                var category = await _categoryRepository.Add(newCategory);
                baseResponse.Data = category;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<Category>()
                {
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteCategory(Guid id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var categoryRemoved = await _categoryRepository.Remove(id);
                baseResponse.Data = categoryRemoved;
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

        public async Task<IBaseResponse<Category>> EditCategory(Guid id, Category updCategory)
        {
            var baseResponse = new BaseResponse<Category>();
            try
            {
                var category = await _categoryRepository.Update(id, updCategory);
                if (category != null)
                {
                    baseResponse.Data = category;
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<Category>()
                {
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Category>> GetCategory(Guid id)
        {
            var baseResponse = new BaseResponse<Category>();
            try
            {

                var category = await _categoryRepository.Get(id);
                baseResponse.Data = category;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<Category>()
                {
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Category>>> GetCategories()
        {
            var baseResponse = new BaseResponse<IEnumerable<Category>>();
            try
            {
                var category = await _categoryRepository.GetAll();
                baseResponse.Data = category;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Category>>()
                {
                    Description = ex.Message
                };
            }
        }
    }
}
