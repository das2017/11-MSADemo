using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DTOEntity;
using ServiceStack.FluentValidation;

namespace Business.Validations
{
    public class OrderValidator : AbstractValidator<OrderRequest>
    {
        public OrderValidator()
        {
            RuleFor(r => r.OrderItemList)                
                .NotEmpty()
                .WithMessage("请指定订单明细列表");
        }
    }
}
