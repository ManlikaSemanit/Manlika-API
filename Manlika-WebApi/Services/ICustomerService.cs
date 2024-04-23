using Manlika_WebApi.Model;

namespace Manlika_WebApi.Services
{
    public interface ICustomerService
    {
        List<CustomerOrderSummary> GetCustomerOrderSummary();
    }
}
