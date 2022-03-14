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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task <IBaseResponse<Order>> AddOrder(Order newOrder)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {
                var order = await _orderRepository.Add(newOrder);
                baseResponse.Data = order;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteOrder(Guid id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var orderRemoved = await _orderRepository.Remove(id);
                baseResponse.Data = orderRemoved;
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

        public async Task<IBaseResponse<Order>> EditOrder(Guid id, Order updOrder)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {
                var order = await _orderRepository.Update(id, updOrder);
                if (order != null)
                {
                    baseResponse.Data = order;
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Order>> GetOrder(Guid id)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {

                var order = await _orderRepository.Get(id);
                baseResponse.Data = order;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Order>>> GetOrders()
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();
            try
            {
                var order = await _orderRepository.GetAll();
                baseResponse.Data = order;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Order>>()
                {
                    Description = ex.Message
                };
            }
        }
    }
}
