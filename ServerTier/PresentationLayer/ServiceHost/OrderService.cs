using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Threading;

using DTOEntity;
using Business;
using Business.IService;
using ServiceStack;

namespace ServiceHost
{
    public class OrderService : Service, IOrderService
    {
        //获取订单列表：
        public OrderListResponse Get(GetOrderListRequest request)
        {
            OrderListResponse result = OrderLogic.Instance.GetOrderList();
            return result;
        }

        //获取指定订单详情：
        public OrderResponse Get(GetOrderRequest request)
        {
            OrderResponse result = OrderLogic.Instance.GetOrder(request);
            if (result == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return default(OrderResponse);
            }

            return result;
        }

        //获取指定订单详情：
        public OrderResponse Post(GetOrderByIdRequest request)
        {
            if (request == null || request.Id < 1)
            {
                throw new Exception("请指定大于0的订单ID");
            }

            string operatorName = Request.Headers.Get("Gateway-OperatorName");

            OrderResponse result = OrderLogic.Instance.GetOrder(request.Id);
            if (result == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return default(OrderResponse);
            }

            return result;
        }

        //新增张订单：
        public OrderResponse Post(OrderRequest request)
        {
            Thread.Sleep(TimeSpan.FromSeconds(18));

            OrderResponse result = OrderLogic.Instance.Add(request);

            Response.AddHeader("Location", Request.AbsoluteUri + "/" + result.Id);
            Response.StatusCode = (int)HttpStatusCode.Created;

            return result;
        }

        //更新指定订单详情：
        public OrderResponse Put(OrderRequest request)
        {
            OrderResponse result = OrderLogic.Instance.GetOrder(request.Id);
            if (result == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return default(OrderResponse);
            }

            result = OrderLogic.Instance.Update(request);

            return result;
        }

        //删除指定订单：
        public HttpResult Delete(DeleteOrderRequest request)
        {
            OrderResponse result = OrderLogic.Instance.GetOrder(request.Id);
            if (result == null)
            {
                return new HttpResult { StatusCode = HttpStatusCode.NotFound };
            }

            OrderLogic.Instance.Delete(request.Id);

            return new HttpResult { StatusCode = HttpStatusCode.OK };
        }
    }
}