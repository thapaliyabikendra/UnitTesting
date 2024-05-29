using UnitTesting.Api.Dtos;
using UnitTesting.Api.Models;

namespace UnitTesting.Api.Interfaces;

public interface IPaymentService
{
    Task<ResponseModel<string>> ProcessPaymentAsync(PaymentRequest request);
}
