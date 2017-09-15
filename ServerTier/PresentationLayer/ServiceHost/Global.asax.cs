using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using DTOEntity;
using Business.Validations;
using ServiceStack;
using ServiceStack.Host;
using ServiceStack.Validation;
using ServiceStack.ProtoBuf;
using ServiceStack.Api.Swagger;
using ServiceStack.Text;

namespace ServiceHost
{
    public class Global : System.Web.HttpApplication
    {
        public class ServiceDemoAppHost : AppHostBase
        {
            public ServiceDemoAppHost()
                : base("MSA API Demo", typeof(ServiceDemoAppHost).Assembly)
            {
                //配置路由规则：
                //如：/orders/[{path参数}.xml|json|html|jsv|csv][(?query参数1={值}&query参数2={值}&......&query参数n={值})]
                Routes.Add<GetOrderListRequest>("/orders", "GET", "获取订单列表")
                      .Add<GetOrderRequest>("/orders/{Id}", "GET", "获取指定订单详情")
                      .Add<OrderRequest>("/orders", "POST", "创建订单")
                      .Add<OrderRequest>("/orders/{Id}", "PUT", "更新指定订单详情")
                      .Add<DeleteOrderRequest>("/orders/{Id}", "DELETE", "删除指定订单")
                      .Add<GetProductListRequest>("/products", "GET", "获取产品列表")
                      .Add<GetProductRequest>("/products/{Id}", "GET", "获取指定产品详情");

                Routes.Add<GetOrderByIdRequest>("/OrderService/GetOrder", "POST", "获取指定订单详情")
                      .Add<OrderRequest>("/OrderService/CreateOrder", "POST", "创建订单");

                //启用请求参数合法性验证功能：
                Plugins.Add(new ValidationFeature());

                Plugins.Add(new ProtoBufFormat());

                JsConfig.EmitCamelCaseNames = false;
                Plugins.Add(new SwaggerFeature());
                Plugins.Add(new CorsFeature("*.test.com"));
            }

            public override void Configure(Funq.Container container)
            {
                //启用请求参数合法性的验证：             
                container.RegisterValidator(typeof(OrderValidator));
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new ServiceDemoAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}