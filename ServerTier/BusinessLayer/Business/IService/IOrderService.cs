using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DTOEntity;
using ServiceStack;

namespace Business.IService
{
    public interface IOrderService
    {
        //获取订单列表：
        OrderListResponse Get(GetOrderListRequest request);
        //获取指定订单详情：
        OrderResponse Get(GetOrderRequest request);
        //获取指定订单详情：
        OrderResponse Post(GetOrderByIdRequest request);
        //新增张订单：
        OrderResponse Post(OrderRequest request);
        //更新指定订单详情：
        OrderResponse Put(OrderRequest request);
        //删除指定订单：
        HttpResult Delete(DeleteOrderRequest request);
    }
}
