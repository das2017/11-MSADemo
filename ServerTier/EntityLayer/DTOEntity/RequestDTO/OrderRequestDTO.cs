using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServiceStack;

namespace DTOEntity
{
    //用于获取订单列表：
    public class GetOrderListRequest : IReturn<OrderListResponse>
    {

    }

    //用于获取指定订单详情：
    public class GetOrderRequest : IReturn<OrderResponse>
    {
        [ApiMember(Name = "Id", Description = "订单ID号", IsRequired = true)]
        public int Id { get; set; }
        [ApiMember(Name = "CustomerName", Description = "客户名", IsRequired = false)]
        public string CustomerName { get; set; }
        [ApiMember(Name = "CreatedDate", Description = "创建订单日期", IsRequired = false)]
        public DateTime CreatedDate { get; set; }
        [ApiMember(Name = "IsTakeAway", Description = "是否已取货", IsRequired = false)]
        public bool? IsTakeAway { get; set; }
        [ApiMember(Name = "StatusCode", Description = "订单状态", IsRequired = false)]
        public StatusCode? StatusCode { get; set; }
    }

    //用于获取指定订单详情：
    public class GetOrderByIdRequest : IReturn<OrderResponse>
    {
        [ApiMember(Name = "Id", Description = "订单ID号", IsRequired = true)]
        public int Id { get; set; }
    }

    //用于删除指定的订单：
    public class DeleteOrderRequest : IReturn<HttpResult>
    {
        [ApiMember(Name = "Id", Description = "订单ID号", IsRequired = true)]
        public int Id { get; set; }
    }

    //用于新增或更新订单：  
    public class OrderRequest : IReturn<OrderResponse>
    {
        [ApiMember(Name = "Id", Description = "订单ID号", IsRequired = true)]
        public int Id { get; set; }
        [ApiMember(Name = "CustomerName", Description = "客户名", IsRequired = false)]
        public string CustomerName { get; set; }
         [ApiMember(Name = "IsTakeAway", Description = "是否已取货", IsRequired = false)]
        public bool IsTakeAway { get; set; }
        [ApiMember(Name = "CreatedDate", Description = "创建订单日期", IsRequired = false)]
        public DateTime CreatedDate { get; set; }
        [ApiMember(Name = "StatusCode", Description = "订单状态", IsRequired = false)]
        public StatusCode StatusCode { get; set; }
        [ApiMember(Name = "OrderItemList", Description = "订购的产品列表", IsRequired = false)]
        public List<OrderItem> OrderItemList { get; set; }
    }

    public class OrderItem
    {
        [ApiMember(Name = "Id", Description = "订单明细Id号", IsRequired = false)]
        public int Id { get; set; }
        [ApiMember(Name = "Product", Description = "所订购的产品", IsRequired = false)]
        public Product Product { get; set; }
        [ApiMember(Name = "Quantity", Description = "产品订购数量", IsRequired = false)]
        public int Quantity { get; set; }
    }

    public class Product
    {
        [ApiMember(Name = "Id", Description = "产品Id号", IsRequired = false)]
        public int Id { get; set; }
        [ApiMember(Name = "Name", Description = "产品名", IsRequired = false)]
        public string Name { get; set; }
        [ApiMember(Name = "StatusCode", Description = "订单状态", IsRequired = false)]
        public StatusCode StatusCode { get; set; }
    }
}
