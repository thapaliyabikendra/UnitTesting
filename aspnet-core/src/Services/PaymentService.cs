using System.Text.RegularExpressions;
using UnitTesting.Api.Dtos;
using UnitTesting.Api.Interfaces;
using UnitTesting.Api.Models;

namespace UnitTesting.Api.Services;
public class PaymentService : IPaymentService
{
    private readonly IPaymentGateway _paymentGateway;

    public PaymentService(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public async Task<ResponseModel<string>> ProcessPaymentAsync(PaymentRequest request)
    {
        var validationResponse = ValidatePaymentRequest(request);
        if (!validationResponse.Success)
        {
            return validationResponse;
        }

        var paymentProcessed = await _paymentGateway.ProcessPaymentAsync(request);
        return paymentProcessed
            ? new ResponseModel<string>(data: "Payment processed successfully")
            : new ResponseModel<string>(error: "Payment processing failed");
    }

    private ResponseModel<string> ValidatePaymentRequest(PaymentRequest request)
    {
        if (request.Amount <= 0)
        {
            return new ResponseModel<string>(error : "Invalid amount");
        }

        if (string.IsNullOrWhiteSpace(request.CardNumber) || !Regex.IsMatch(request.CardNumber, @"^\d{16}$"))
        {
            return new ResponseModel<string>(error: "Invalid card number");
        }

        if (string.IsNullOrWhiteSpace(request.CardExpiry) || !Regex.IsMatch(request.CardExpiry, @"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$"))
        {
            return new ResponseModel<string>(error: "Invalid card expiry");
        }

        if (string.IsNullOrWhiteSpace(request.CardCvv) || !Regex.IsMatch(request.CardCvv, @"^\d{3}$"))
        {
            return new ResponseModel<string>(error: "Invalid card CVV");
        }

        return new ResponseModel<string>(data: "Validation successful");
    }
}