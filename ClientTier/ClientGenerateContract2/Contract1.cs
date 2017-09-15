/* Options:
Date: 2017-08-17 17:40:21
Version: 4.00
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://localhost:34833

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//IncludeTypes: 
//ExcludeTypes: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace ServiceContract
{

    [Route("/orders/{Id}", "DELETE")]
    public partial class DeleteOrderRequest
        : IReturn<HttpResult>
    {
        ///<summary>
        ///订单ID号
        ///</summary>
        [ApiMember(Name="Id", Description="订单ID号", IsRequired=true)]
        public virtual int Id { get; set; }
    }

    [Route("/OrderService/GetOrder", "POST")]
    public partial class GetOrderByIdRequest
        : IReturn<OrderResponse>
    {
        ///<summary>
        ///订单ID号
        ///</summary>
        [ApiMember(Name="Id", Description="订单ID号", IsRequired=true)]
        public virtual int Id { get; set; }
    }

    [Route("/orders", "GET")]
    public partial class GetOrderListRequest
        : IReturn<OrderListResponse>
    {
    }

    [Route("/orders/{Id}", "GET")]
    public partial class GetOrderRequest
        : IReturn<OrderResponse>
    {
        ///<summary>
        ///订单ID号
        ///</summary>
        [ApiMember(Name="Id", Description="订单ID号", IsRequired=true)]
        public virtual int Id { get; set; }

        ///<summary>
        ///客户名
        ///</summary>
        [ApiMember(Name="CustomerName", Description="客户名")]
        public virtual string CustomerName { get; set; }

        ///<summary>
        ///创建订单日期
        ///</summary>
        [ApiMember(Name="CreatedDate", Description="创建订单日期")]
        public virtual DateTime CreatedDate { get; set; }

        ///<summary>
        ///是否已取货
        ///</summary>
        [ApiMember(Name="IsTakeAway", Description="是否已取货")]
        public virtual bool? IsTakeAway { get; set; }

        ///<summary>
        ///订单状态
        ///</summary>
        [ApiMember(Name="StatusCode", Description="订单状态")]
        public virtual StatusCode? StatusCode { get; set; }
    }

    [Route("/products", "GET")]
    [DataContract]
    public partial class GetProductListRequest
        : IReturn<ProductListResponse>
    {
    }

    [Route("/products/{Id}", "GET")]
    [DataContract]
    public partial class GetProductRequest
        : IReturn<ProductResponse>
    {
        ///<summary>
        ///产品ID号
        ///</summary>
        [DataMember(Order=1)]
        [ApiMember(Name="Id", Description="产品ID号", IsRequired=true)]
        public virtual int Id { get; set; }

        ///<summary>
        ///产品名
        ///</summary>
        [DataMember(Order=2)]
        [ApiMember(Name="Name", Description="产品名")]
        public virtual string Name { get; set; }
    }

    public partial class OrderItem
    {
        ///<summary>
        ///订单明细Id号
        ///</summary>
        [ApiMember(Name="Id", Description="订单明细Id号")]
        public virtual int Id { get; set; }

        ///<summary>
        ///所订购的产品
        ///</summary>
        [ApiMember(Name="Product", Description="所订购的产品")]
        public virtual Product Product { get; set; }

        ///<summary>
        ///产品订购数量
        ///</summary>
        [ApiMember(Name="Quantity", Description="产品订购数量")]
        public virtual int Quantity { get; set; }
    }

    public partial class OrderItemResponse
    {
        ///<summary>
        ///订单明细Id号
        ///</summary>
        [ApiMember(Name="Id", Description="订单明细Id号")]
        public virtual int Id { get; set; }

        ///<summary>
        ///所订购的产品
        ///</summary>
        [ApiMember(Name="Product", Description="所订购的产品")]
        public virtual ProductResponse Product { get; set; }

        ///<summary>
        ///产品订购数量
        ///</summary>
        [ApiMember(Name="Quantity", Description="产品订购数量")]
        public virtual int Quantity { get; set; }
    }

    public partial class OrderListResponse
    {
        public OrderListResponse()
        {
            OrderList = new List<OrderResponse>{};
        }

        ///<summary>
        ///订单列表
        ///</summary>
        [ApiMember(Name="OrderList", Description="订单列表")]
        public virtual List<OrderResponse> OrderList { get; set; }
    }

    [Route("/orders", "POST")]
    [Route("/orders/{Id}", "PUT")]
    [Route("/OrderService/CreateOrder", "POST")]
    public partial class OrderRequest
        : IReturn<OrderResponse>
    {
        public OrderRequest()
        {
            OrderItemList = new List<OrderItem>{};
        }

        ///<summary>
        ///订单ID号
        ///</summary>
        [ApiMember(Name="Id", Description="订单ID号", IsRequired=true)]
        public virtual int Id { get; set; }

        ///<summary>
        ///客户名
        ///</summary>
        [ApiMember(Name="CustomerName", Description="客户名")]
        public virtual string CustomerName { get; set; }

        ///<summary>
        ///是否已取货
        ///</summary>
        [ApiMember(Name="IsTakeAway", Description="是否已取货")]
        public virtual bool IsTakeAway { get; set; }

        ///<summary>
        ///创建订单日期
        ///</summary>
        [ApiMember(Name="CreatedDate", Description="创建订单日期")]
        public virtual DateTime CreatedDate { get; set; }

        ///<summary>
        ///订单状态
        ///</summary>
        [ApiMember(Name="StatusCode", Description="订单状态")]
        public virtual StatusCode StatusCode { get; set; }

        ///<summary>
        ///订购的产品列表
        ///</summary>
        [ApiMember(Name="OrderItemList", Description="订购的产品列表")]
        public virtual List<OrderItem> OrderItemList { get; set; }
    }

    public partial class OrderResponse
    {
        public OrderResponse()
        {
            OrderItemList = new List<OrderItemResponse>{};
        }

        ///<summary>
        ///订单Id号
        ///</summary>
        [ApiMember(Name="Id", Description="订单Id号")]
        public virtual int Id { get; set; }

        ///<summary>
        ///客户名
        ///</summary>
        [ApiMember(Name="CustomerName", Description="客户名")]
        public virtual string CustomerName { get; set; }

        ///<summary>
        ///是否已取货
        ///</summary>
        [ApiMember(Name="IsTakeAway", Description="是否已取货")]
        public virtual bool IsTakeAway { get; set; }

        ///<summary>
        ///订单创建日期
        ///</summary>
        [ApiMember(Name="CreatedDate", Description="订单创建日期")]
        public virtual DateTime CreatedDate { get; set; }

        ///<summary>
        ///订单状态
        ///</summary>
        [ApiMember(Name="StatusCode", Description="订单状态")]
        public virtual StatusCode StatusCode { get; set; }

        ///<summary>
        ///订单明细列表
        ///</summary>
        [ApiMember(Name="OrderItemList", Description="订单明细列表")]
        public virtual List<OrderItemResponse> OrderItemList { get; set; }
    }

    public partial class Product
    {
        ///<summary>
        ///产品Id号
        ///</summary>
        [ApiMember(Name="Id", Description="产品Id号")]
        public virtual int Id { get; set; }

        ///<summary>
        ///产品名
        ///</summary>
        [ApiMember(Name="Name", Description="产品名")]
        public virtual string Name { get; set; }

        ///<summary>
        ///订单状态
        ///</summary>
        [ApiMember(Name="StatusCode", Description="订单状态")]
        public virtual StatusCode StatusCode { get; set; }
    }

    [DataContract]
    public partial class ProductListResponse
    {
        public ProductListResponse()
        {
            ProductList = new List<ProductResponse>{};
        }

        ///<summary>
        ///产品列表
        ///</summary>
        [DataMember(Order=1)]
        [ApiMember(Name="ProductList", Description="产品列表")]
        public virtual List<ProductResponse> ProductList { get; set; }
    }

    [DataContract]
    public partial class ProductResponse
    {
        ///<summary>
        ///产品Id号
        ///</summary>
        [DataMember(Order=1)]
        [ApiMember(Name="Id", Description="产品Id号")]
        public virtual int Id { get; set; }

        ///<summary>
        ///产品名
        ///</summary>
        [DataMember(Order=2)]
        [ApiMember(Name="Name", Description="产品名")]
        public virtual string Name { get; set; }

        ///<summary>
        ///订单状态
        ///</summary>
        [DataMember(Order=3)]
        [ApiMember(Name="StatusCode", Description="订单状态")]
        public virtual StatusCode StatusCode { get; set; }
    }

    public enum StatusCode
    {
        InActive = 0,
        Active = 1,
        NotSet = -1,
    }
}

