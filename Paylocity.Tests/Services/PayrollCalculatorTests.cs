using Moq;
using Paylocity.Models;
using Paylocity.Services;
using Xunit;

namespace Paylocity.Tests.Services
{
    public class PayrollCalculatorTests
    {
        private IBenefitsCalculator GetMockBenefitsCalculator(decimal totalCostOfBenefits)
        {
            var benefitsCalculator = new Mock<IBenefitsCalculator>();
            benefitsCalculator.Setup(b => b.CostOfBenefits(It.IsAny<Employee>())).Returns(totalCostOfBenefits);
            return benefitsCalculator.Object;
        }

        private Employee GetEmployee()
        {
            return new Employee("Regular", "Employee");
        }

        [Fact]
        void EmployeesShouldMake2000PerPaycheckBeforeDeductions()
        {
            var payrollCalculator = new PayrollCalculator(GetMockBenefitsCalculator(0));

            var grossPay = payrollCalculator.GrossPayPerPeriod(GetEmployee());

            Assert.Equal(2000, grossPay);
        }

        [Fact]
        void GrossPayShouldIncludeCostOfBenefitsDeductions()
        {

            const int numPaychecksPerYear = 26;
            const decimal expectedPay = 2000M - 1000M / (decimal) numPaychecksPerYear;
            var payrollCalculator = new PayrollCalculator(GetMockBenefitsCalculator(1000));

            var grossPay = payrollCalculator.GrossPayPerPeriod(GetEmployee());

            Assert.Equal(expectedPay, grossPay);
        }
    }
}
