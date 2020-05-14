﻿using System;
using System.Collections.Generic;
using System.Linq;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderOptions options);
        List<Order> SearchOrder(SearchOrderOptions options);
        Order UpdateOrder(UpdateOrderOptions options);
        Order GetOrderById(int id);
    }
}
