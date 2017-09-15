using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DTOEntity;

namespace Business
{
    public class OrderLogic
    {
        private static readonly OrderListResponse orderList = new OrderListResponse();        

        private static readonly OrderLogic _instance = new OrderLogic();
        public static OrderLogic Instance
        {
            get
            {
                return _instance;
            }
        }

        public OrderLogic()
        {
            if (orderList.OrderList == null || !orderList.OrderList.Any())
            {
                orderList.OrderList = new List<OrderResponse>();

                List<OrderItemResponse> orderItemList = GetExampleOrderItemList(6, 15, 2, 20);
                orderList.OrderList.Add(GetExampleOrder(1, true, StatusCode.Active, orderItemList));

                orderItemList = GetExampleOrderItemList(3, 20, 4, 15);
                orderList.OrderList.Add(GetExampleOrder(2, false, StatusCode.Active, orderItemList));

                orderItemList = GetExampleOrderItemList(1, 150, 5, 200);
                orderList.OrderList.Add(GetExampleOrder(3, true, StatusCode.InActive, orderItemList));
            }
        }

        public OrderListResponse GetOrderList()
        {
            return orderList;
        }

        public OrderResponse GetOrder(GetOrderRequest request)
        {
            OrderResponse result = orderList.OrderList.FirstOrDefault(x => x.Id == request.Id);
            if (result != null)
            {
                if ((!string.IsNullOrWhiteSpace(request.CustomerName) && !result.CustomerName.Equals(request.CustomerName))
                    || (request.CreatedDate != DateTime.MinValue && result.CreatedDate.Date != request.CreatedDate.Date)
                    || (request.StatusCode.HasValue && result.StatusCode != request.StatusCode)
                    || (request.IsTakeAway.HasValue && result.IsTakeAway != request.IsTakeAway)
                    )
                {
                    return null;
                }
            }

            return result;
        }

        public OrderResponse GetOrder(int orderId)
        {
            return orderList.OrderList.FirstOrDefault(x => x.Id == orderId);
        }

        public OrderResponse Add(OrderRequest request)
        {
            OrderResponse result = new OrderResponse
            {
                Id = orderList.OrderList.Count > 0 ? orderList.OrderList.Max(x => x.Id) + 1 : 1,
                CustomerName = request.CustomerName,
                IsTakeAway = request.IsTakeAway,
                CreatedDate = request.CreatedDate,
                StatusCode = request.StatusCode
            };

            result.OrderItemList = new List<OrderItemResponse>();
            for (int i = 0; i < request.OrderItemList.Count; ++i)
            {
                OrderItem orderItemRequest = request.OrderItemList[i];

                OrderItemResponse orderItemResult = new OrderItemResponse
                {
                    Id = i + 1,
                    Quantity = orderItemRequest.Quantity
                };

                if (orderItemRequest.Product != null)
                {
                    orderItemResult.Product = ProductLogic.Instance.GetProduct(orderItemRequest.Product.Id);
                }

                result.OrderItemList.Add(orderItemResult);
            }

            orderList.OrderList.Add(result);

            return result;
        }

        public OrderResponse Update(OrderRequest request)
        {
            OrderResponse result = GetOrder(request.Id);
            result.IsTakeAway = request.IsTakeAway;
            result.CustomerName = request.CustomerName;
            result.CreatedDate = request.CreatedDate;
            result.StatusCode = request.StatusCode;

            foreach (OrderItemResponse orderItemResult in result.OrderItemList)
            {
                OrderItem tempRequest = request.OrderItemList.FirstOrDefault(r => r.Id == orderItemResult.Id);
                if (tempRequest == null)
                {
                    continue;
                }

                orderItemResult.Quantity = tempRequest.Quantity;
                if (tempRequest.Product != null)
                {
                    orderItemResult.Product = ProductLogic.Instance.GetProduct(tempRequest.Product.Id);
                }
            }

            return result;
        }

        public void Delete(int orderId)
        {
            OrderResponse order = GetOrder(orderId);
            if (order != null)
            {
                orderList.OrderList.Remove(order);
            }
        }

        private List<OrderItemResponse> GetExampleOrderItemList(int productId1, int quantity1, int productId2, int quantity2)
        {
            List<OrderItemResponse> orderItemList = new List<OrderItemResponse>()
            {
                new OrderItemResponse
                {
                    Id = 1,
                    Product = ProductLogic.Instance.GetProduct(productId1),                  
                    Quantity = quantity1
                },
                new OrderItemResponse
                {
                    Id = 2,
                    Product = ProductLogic.Instance.GetProduct(productId2),
                    Quantity = quantity2
                }
            };
            return orderItemList;
        }

        private OrderResponse GetExampleOrder(int orderId, bool isTakeAway, StatusCode statusCode, List<OrderItemResponse> orderItemList)
        {
            OrderResponse order = new OrderResponse
            {
                Id = orderId,
                CustomerName = string.Format("客户_{0}", orderId),
                IsTakeAway = isTakeAway,
                CreatedDate = DateTime.Now,
                StatusCode = statusCode
            };

            order.OrderItemList = new List<OrderItemResponse>();
            for (int i = 1; i <= orderItemList.Count; ++i)
            {
                order.OrderItemList.Add(orderItemList[i - 1]);
            }

            return order;
        }
    }
}
