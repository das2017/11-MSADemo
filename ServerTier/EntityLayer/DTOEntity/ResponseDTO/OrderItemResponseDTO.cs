using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServiceStack;

namespace DTOEntity
{
    public class OrderItemListResponse
    {
        [ApiMember(Name = "ItemList", Description = "订单明细列表", IsRequired = false)]
        public List<OrderItemResponse> ItemList { get; set; }
    }

    public class OrderItemResponse
    {
        [ApiMember(Name = "Id", Description = "订单明细Id号", IsRequired = false)]
        public int Id { get; set; }
        [ApiMember(Name = "Product", Description = "所订购的产品", IsRequired = false)]
        public ProductResponse Product { get; set; }
        [ApiMember(Name = "Quantity", Description = "产品订购数量", IsRequired = false)]
        public int Quantity { get; set; }
    }
}
