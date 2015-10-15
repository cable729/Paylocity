using Paylocity.Models;

namespace Paylocity.Services
{
    public class PayrollCalculator : IPayrollCalculator
    {
        private readonly IBenefitsCalculator benefitsCalculator;
        private const int PayPeriodsPerYear = 26;
        private const decimal BasePay = 2000M;

        public PayrollCalculator(IBenefitsCalculator benefitsCalculator)
        {
            this.benefitsCalculator = benefitsCalculator;
        }

        public decimal GrossPayPerPeriod(Employee employee)
        {
            var deductionPerPayPeriod = benefitsCalculator.CostOfBenefits(employee) / PayPeriodsPerYear;
            return BasePay - deductionPerPayPeriod;
        }
    }
}