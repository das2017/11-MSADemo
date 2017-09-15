using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using ServiceStack;

namespace DTOEntity
{
    [DataContract]
    public class ProductListResponse
    {
        [ApiMember(Name = "ProductList", Description = "产品列表", IsRequired = false)]
        [DataMember(Order = 1)]       
        public List<ProductResponse> ProductList { get; set; }
    }

    [DataContract]
    public class ProductResponse
    {
        [ApiMember(Name = "Id", Description = "产品Id号", IsRequired = false)]
        [DataMember(Order = 1)]       
        public int Id { get; set; }
        [ApiMember(Name = "Name", Description = "产品名", IsRequired = false)]
        [DataMember(Order = 2)]      
        public string Name { get; set; }        
        [ApiMember(Name = "StatusCode", Description = "订单状态", IsRequired = false)]
        [DataMember(Order = 3)]
        public StatusCode StatusCode { get; set; }
    }
}
