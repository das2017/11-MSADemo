using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using ServiceStack;

namespace DTOEntity
{
    [DataContract]
    public class GetProductListRequest : IReturn<ProductListResponse>
    {
    }

    [DataContract]
    public class GetProductRequest : IReturn<ProductResponse>
    {
        [ApiMember(Name = "Id", Description = "产品ID号", IsRequired=true)]
        [DataMember(Order = 1)]      
        public int Id { get; set; }
        [ApiMember(Name = "Name", Description = "产品名", IsRequired = false)]
        [DataMember(Order = 2)]      
        public string Name { get; set; }
    }
}
