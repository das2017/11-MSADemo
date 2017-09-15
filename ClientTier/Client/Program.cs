using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using ServiceContract;
using ServiceStack;
using ServiceStack.Text;
using ServiceStack.ProtoBuf;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderEMSAClient orderEMSAClient = new OrderEMSAClient();
            orderEMSAClient.GetOrderListWithJsonServClt();
            orderEMSAClient.GetOrderWithJsonServClt();
            orderEMSAClient.CreateOrderWithJsonServClt();
            orderEMSAClient.UpdateOrderWithJsonServClt();
            orderEMSAClient.DeleteOrderWithJsonServClt();

            ProductEMSAClient productEMSAClient = new ProductEMSAClient();
            productEMSAClient.GetProductListWithProtoBufServClt();
            productEMSAClient.GetProductWithProtoBufServClt();
        }        
    }
}
