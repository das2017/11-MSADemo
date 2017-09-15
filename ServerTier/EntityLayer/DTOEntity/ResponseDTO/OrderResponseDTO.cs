using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServiceStack;

namespace DTOEntity
{
    public class OrderListResponse
    {
        [ApiMember(Name = "OrderList", Description = "订单列表", IsRequired = false)]
        public List<OrderResponse> OrderList { get; set; }
    }

    public class OrderResponse
    {
        [ApiMember(Name = "Id", Description = "订单Id号", IsRequired = false)]
        public int Id { get; set; }
        [ApiMember(Name = "CustomerName", Description = "客户名", IsRequired = false)]
        public string CustomerName { get; set; }
        [ApiMember(Name = "IsTakeAway", Description = "是否已取货", IsRequired = false)]
        public bool IsTakeAway { get; set; }
        [ApiMember(Name = "CreatedDate", Description = "订单创建日期", IsRequired = false)]
        public DateTime CreatedDate { get; set; }
        [ApiMember(Name = "StatusCode", Description = "订单状态", IsRequired = false)]
        public StatusCode StatusCode { get; set; }
        [ApiMember(Name = "OrderItemList", Description = "订单明细列表", IsRequired = false)]
        public List<OrderItemResponse> OrderItemList { get; set; }
    }
}
