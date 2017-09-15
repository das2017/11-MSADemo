using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using ServiceContract;
using ServiceStack;
using ServiceStack.Text;

namespace Client
{
    class OrderEMSAClient
    {
        protected const string listenOnUrl = "http://localhost:34833/";

        public void GetOrderListWithJsonServClt()
        {
            GetOrderListRequest request = new GetOrderListRequest();

            OrderListResponse response = null;
            using (JsonServiceClient client = new JsonServiceClient(listenOnUrl))
            {
                response = client.Get<OrderListResponse>(request);
            }

            if (response != null)
            {
                response.PrintDump();
            }
            Console.WriteLine("成功获取所有订单。");
            Console.ReadLine();
        }

        public void GetOrderWithJsonServClt()
        {
            GetOrderRequest request = new GetOrderRequest
            {
                Id = 1,
                CustomerName = "客户_1",
                //IsTakeAway = true,
                StatusCode = StatusCode.Active,
                CreatedDate = DateTime.Now
            };

            OrderResponse response = null;
            using (JsonServiceClient client = new JsonServiceClient(listenOnUrl))
            {
                response = client.Get<OrderResponse>(request);
            }

            if (response != null)
            {
                response.PrintDump();
            }
            Console.WriteLine("成功获取指定的订单详情。");
            Console.ReadLine();
        }

        public void CreateOrderWithJsonServClt()
        {
            OrderRequest request = new OrderRequest
            {
                CreatedDate = DateTime.Now,
                CustomerName = "客户_4",
                IsTakeAway = true,
                StatusCode = StatusCode.Active,
                OrderItemList = new List<OrderItem>
                {
                    new OrderItem 
                    { 
                        Product = new Product 
                        { 
                            Id = 7 
                        }, 
                        Quantity = 20 
                    },
                    new OrderItem 
                    { 
                        Product = new Product 
                        { 
                            Id = 11
                        }, 
                        Quantity = 15
                    }
                }
            };

            WebHeaderCollection headers = null;
            HttpStatusCode statusCode = 0;
            OrderResponse orderResponse = null;
            using (JsonServiceClient client = new JsonServiceClient(listenOnUrl))
            {
                client.ResponseFilter =
                     httpRes =>
                     {
                         headers = httpRes.Headers;
                         statusCode = httpRes.StatusCode;
                     };

                orderResponse = client.Post<OrderResponse>(request);
            }

            if (orderResponse != null)
            {
                orderResponse.PrintDump();
            }
            Console.WriteLine("新增订单操作成功，订单ID号为{0}。", orderResponse.Id);
            Console.ReadLine();
        }

        public void UpdateOrderWithJsonServClt()
        {
            OrderRequest request = new OrderRequest
            {
                Id = 2,
                CustomerName = "客户_2_updated",
                CreatedDate = new DateTime(2013, 08, 08),
                IsTakeAway = true,
                StatusCode = StatusCode.InActive,
                OrderItemList = new List<OrderItem>
                {
                    new OrderItem 
                    {
                        Id = 2,                       
                        Product = new Product { Id = 20 },                        
                        Quantity = 100 
                    }
                }
            };

            HttpStatusCode statusCode = 0;
            OrderResponse orderResponse = null;
            using (JsonServiceClient client = new JsonServiceClient(listenOnUrl))
            {
                client.ResponseFilter =
                    httpRes =>
                    {
                        statusCode = httpRes.StatusCode;
                    };

                orderResponse = client.Put<OrderResponse>(request);
            };

            if (orderResponse != null)
            {
                orderResponse.PrintDump();
            }
            Console.WriteLine("成功更新订单ID号为{0}的订单。", request.Id);
            Console.ReadLine();
        }

        public void DeleteOrderWithJsonServClt()
        {
            DeleteOrderRequest request = new DeleteOrderRequest
            {
                Id = 4
            };

            HttpStatusCode statusCode = 0;
            using (JsonServiceClient client = new JsonServiceClient(listenOnUrl))
            {
                client.ResponseFilter =
                    httpRes =>
                    {
                        statusCode = httpRes.StatusCode;
                    };

                client.Delete<HttpResult>(request);
            };

            Console.WriteLine("成功删除订单ID号为{0}的订单。", request.Id);
            Console.ReadLine();
        }
    }    
}
