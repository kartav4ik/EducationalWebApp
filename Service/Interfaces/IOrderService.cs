using AppDomain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain.Models;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseResponse<IEnumerable<Order>>> GetOrders();
        Task<IBaseResponse<Order>> GetOrder(Guid id);
        Task<IBaseResponse<Order>> AddOrder(Order newOrder);
        Task<IBaseResponse<Order>> EditOrder(Guid id, Order updOrder);
        Task<IBaseResponse<bool>> DeleteOrder(Guid id);
    }
}
