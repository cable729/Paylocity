using Paylocity.Models;
using Paylocity.Services;
using Xunit;

namespace Paylocity.Tests.Services
{
    public class BenefitsCalculatorTests
    {
        readonly IBenefitsCalculator calculator = new BenefitsCalculator();

        [Fact]
        void EmployeeCostShouldNormallyBe1000()
        {
            var employee = new Employee("Caleb", "Jares");
            var cost = calculator.CostOfBenefits(employee);
            Assert.Equal(1000, cost);
        }

        [Fact]
        void EmployeesWithNamesThatStartWithAShouldGetADiscount()
        {
            var employee = new Employee("Apollo", "Astronaut");
            var cost = calculator.CostOfBenefits(employee);
            Assert.Equal(900, cost);
        }

        [Fact]
        void EmployeesWithDependentsShouldBeChargedMore()
        {
            var dependents = new[] {new Person("Bill", "Gates"), new Person("Roger", "Waters") };
            var employee = new Employee("Jack", "theRipper", dependents);
            var cost = calculator.CostOfBenefits(employee);
            Assert.Equal(1000 + 500 * 2, cost);
        }

        [Fact]
        void EmployeeWithAnANameDependentShouldGetADiscount()
        {
            var dependents = new[] { new Person("A", "Discount"), new Person("Not", "Discounted"), new Person("Boom", "Boom"),  };
            var employee = new Employee("Some", "Person", dependents);
            var cost = calculator.CostOfBenefits(employee);
            Assert.Equal((decimal) (1000 + 500 + 500 + 500 * .9), cost);
        }
    }
}
