using Paylocity.Models;

namespace Paylocity.Services
{
    public interface IPayrollCalculator
    {
        decimal GrossPayPerPeriod(Employee employee);
    }
}
