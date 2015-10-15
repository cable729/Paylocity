using Paylocity.Models;

namespace Paylocity.Services
{
    public interface IBenefitsCalculator
    {
        decimal CostOfBenefits(Employee employee);
    }
}
