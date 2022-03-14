using AppDomain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain.Models;

namespace Service.Interfaces
{
    public interface ICategoryService 
    {
        Task<IBaseResponse<IEnumerable<Category>>> GetCategories();
        Task<IBaseResponse<Category>> GetCategory(Guid id);
        Task<IBaseResponse<Category>> AddCategory(Category newCategory);
        Task<IBaseResponse<Category>> EditCategory(Guid id, Category updCategoryr);
        Task<IBaseResponse<bool>> DeleteCategory(Guid id);
    }
}
