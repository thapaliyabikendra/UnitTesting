using UnitTesting.Api.Dtos;
using UnitTesting.Api.Models;

namespace UnitTesting.Api.Interfaces;

public interface IPaymentGateway
{
    Task<bool> ProcessPaymentAsync(PaymentRequest request);
}
