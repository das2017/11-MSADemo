using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DTOEntity;

namespace Business
{
    public class ProductLogic
    {
        private static readonly ProductListResponse productList = new ProductListResponse();

        private static readonly ProductLogic _instance = new ProductLogic();
        public static ProductLogic Instance
        {
            get
            {
                return _instance;
            }
        }

        public ProductLogic()
        {
            if (productList.ProductList == null || !productList.ProductList.Any())
            {
                productList.ProductList = new List<ProductResponse>();

                for (int i = 1; i < 51; i++)
                {
                    productList.ProductList.Add(new ProductResponse()
                    {
                        Id = i,
                        Name = "产品_" + i,
                        StatusCode = StatusCode.Active
                    });
                }
            }
        }

        public ProductListResponse GetProductList()
        {
            return productList;
        }

        public ProductResponse GetProduct(GetProductRequest request)
        {
            ProductResponse result = productList.ProductList.FirstOrDefault(x => x.Id == request.Id);
            if (result != null)
            {
                if (!string.IsNullOrWhiteSpace(request.Name) && !result.Name.Equals(request.Name))
                {
                    return null;
                }
            }

            return result;
        }

        public ProductResponse GetProduct(int productId)
        {
            return productList.ProductList.FirstOrDefault(x => x.Id == productId);
        }
    }
}
