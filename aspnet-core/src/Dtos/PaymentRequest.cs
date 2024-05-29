namespace UnitTesting.Api.Dtos;

public class PaymentRequest
{
    public decimal Amount { get; set; }
    public string CardNumber { get; set; }
    public string CardExpiry { get; set; }
    public string CardCvv { get; set; }
}
