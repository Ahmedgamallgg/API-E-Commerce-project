using Services.BasketServices.Services.Dto;
using Services.OrderService.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StripePaymentService.Interface
{
    public interface IPaymentService
    {
        Task<CustomerBasketDto> CreateOrUpdatePaymentIntent(string basketId);

        Task<OrderResultDto> UpdateOrderPaymentSecceeded(string paymentIntentId);

        Task<OrderResultDto> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}
