using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

using DTOEntity;
using Business;
using Business.IService;
using ServiceStack;

namespace ServiceHost
{
    public class ProductService : Service, IProductService
    {
        //获取产品列表：
        public ProductListResponse Get(GetProductListRequest request)
        {
            ProductListResponse result = ProductLogic.Instance.GetProductList();
            return result;
        }

        //获取指定产品详情：
        public ProductResponse Get(GetProductRequest request)
        {
            ProductResponse result = ProductLogic.Instance.GetProduct(request);
            if (result == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return default(ProductResponse);
            }

            return result;
        }
    }
}