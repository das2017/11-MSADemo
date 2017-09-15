using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServiceContract;
using ServiceStack.Text;
using ServiceStack.ProtoBuf;

namespace Client
{
    class ProductEMSAClient
    {
        protected const string listenOnUrl = "http://localhost:34833/";   

        public void GetProductListWithProtoBufServClt()
        {
            GetProductListRequest request = new GetProductListRequest();

            ProductListResponse response = null;
            using (ProtoBufServiceClient client = new ProtoBufServiceClient(listenOnUrl))
            {
                response = client.Get<ProductListResponse>(request);
            }

            if (response != null)
            {
                response.PrintDump();
            }
            Console.WriteLine("成功获取所有产品。");
            Console.ReadLine();
        }

        public void GetProductWithProtoBufServClt()
        {
            GetProductRequest request = new GetProductRequest
            {
                Id = 1,
                Name = "产品_1"
            };

            ProductResponse response = null;
            using (ProtoBufServiceClient client = new ProtoBufServiceClient(listenOnUrl))
            {
                response = client.Get<ProductResponse>(request);
            }

            if (response != null)
            {
                response.PrintDump();
            }
            Console.WriteLine("成功获取指定的产品详情。");
            Console.ReadLine();
        }
    }
}
