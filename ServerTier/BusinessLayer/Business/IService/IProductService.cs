using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DTOEntity;

namespace Business.IService
{
    public interface IProductService
    {
        //获取产品列表：
        ProductListResponse Get(GetProductListRequest request);
        //获取指定产品详情：
        ProductResponse Get(GetProductRequest request);
    }
}
