using NSubstitute;
using Shouldly;
using UnitTesting.Api.Dtos;
using UnitTesting.Api.Interfaces;
using UnitTesting.Api.Services;

namespace UnitTesting.Tests.Services;
public class PaymentServiceTests
{
    private readonly IPaymentGateway _paymentGateway;
    private readonly IPaymentService _paymentService;

    public PaymentServiceTests()
    {
        _paymentGateway = Substitute.For<IPaymentGateway>();
        _paymentService = new PaymentService(_paymentGateway);
    }

    [Fact]
    public async Task ProcessPaymentAsync_ShouldReturnError_WhenAmountIsInvalid()
    {
        // Arrange
        var request = new PaymentRequest
        {
            Amount = -1,
            CardNumber = "1234567812345678",
            CardExpiry = "12/23",
            CardCvv = "123"
        };

        // Act
        var response = await _paymentService.ProcessPaymentAsync(request);

        // Assert
        response.ShouldNotBeNull();
        response.Success.ShouldBeFalse();
        response.Errors.ShouldContain("Invalid amount");
    }

    [Fact]
    public async Task ProcessPaymentAsync_ShouldReturnError_WhenCardNumberIsInvalid()
    {
        // Arrange
        var request = new PaymentRequest
        {
            Amount = 100,
            CardNumber = "123",
            CardExpiry = "12/23",
            CardCvv = "123"
        };

        // Act
        var response = await _paymentService.ProcessPaymentAsync(request);

        // Assert
        response.ShouldNotBeNull();
        response.Success.ShouldBeFalse();
        response.Errors.ShouldContain("Invalid card number");
    }

    [Fact]
    public async Task ProcessPaymentAsync_ShouldReturnError_WhenCardExpiryIsInvalid()
    {
        // Arrange
        var request = new PaymentRequest
        {
            Amount = 100,
            CardNumber = "1234567812345678",
            CardExpiry = "invalid",
            CardCvv = "123"
        };

        // Act
        var response = await _paymentService.ProcessPaymentAsync(request);

        // Assert
        response.ShouldNotBeNull();
        response.Success.ShouldBeFalse();
        response.Errors.ShouldContain("Invalid card expiry");
    }

    [Fact]
    public async Task ProcessPaymentAsync_ShouldReturnError_WhenCardCvvIsInvalid()
    {
        // Arrange
        var request = new PaymentRequest
        {
            Amount = 100,
            CardNumber = "1234567812345678",
            CardExpiry = "12/23",
            CardCvv = "12"
        };

        // Act
        var response = await _paymentService.ProcessPaymentAsync(request);

        // Assert
        response.ShouldNotBeNull();
        response.Success.ShouldBeFalse();
        response.Errors.ShouldContain("Invalid card CVV");
    }

    [Fact]
    public async Task ProcessPaymentAsync_ShouldReturnError_WhenPaymentProcessingFails()
    {
        // Arrange
        var request = new PaymentRequest
        {
            Amount = 100,
            CardNumber = "1234567812345678",
            CardExpiry = "12/23",
            CardCvv = "123"
        };

        _paymentGateway.ProcessPaymentAsync(request).Returns(false);

        // Act
        var response = await _paymentService.ProcessPaymentAsync(request);

        // Assert
        response.ShouldNotBeNull();
        response.Success.ShouldBeFalse();
        response.Errors.ShouldContain("Payment processing failed");
    }


    [Fact]
    public async Task ProcessPaymentAsync_ShouldReturnSuccess_WhenRequestIsValid()
    {
        // Arrange
        var request = new PaymentRequest
        {
            Amount = 100,
            CardNumber = "1234567812345678",
            CardExpiry = "12/23",
            CardCvv = "123"
        };

        _paymentGateway.ProcessPaymentAsync(request).Returns(true);

        // Act
        var response = await _paymentService.ProcessPaymentAsync(request);

        // Assert
        response.ShouldNotBeNull();
        response.Success.ShouldBeTrue();
        response.Data.ShouldBe("Payment processed successfully");
    }
}