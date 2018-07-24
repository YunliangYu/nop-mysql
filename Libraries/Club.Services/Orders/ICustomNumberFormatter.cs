using Club.Core.Domain.Orders;

namespace Club.Services.Orders
{
    public partial interface ICustomNumberFormatter
    {
        string GenerateReturnRequestCustomNumber(ReturnRequest returnRequest);

        string GenerateOrderCustomNumber(Order order);
    }
}