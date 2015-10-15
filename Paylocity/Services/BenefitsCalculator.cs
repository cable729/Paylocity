using System.Linq;
using Paylocity.Models;

namespace Paylocity.Services
{
    public class BenefitsCalculator : IBenefitsCalculator
    {
        private const decimal CostForEmployee = 1000M;
        private const decimal CostForDependent = 500M;
        private const decimal NameStartsWithADiscountPercentage = .10M;

        public decimal CostOfBenefits(Employee employee)
        {
            var employeeCost = CostForEmployee * (1 - PercentageDiscountForPerson(employee));
            var dependentCost = CostForDependent * employee.Dependents.Count() - TotalDependentsDiscount(employee);
            return employeeCost + dependentCost;
        }

        private decimal TotalDependentsDiscount(Employee employee)
        {
            return employee.Dependents.Sum(dependent => CostForDependent * PercentageDiscountForPerson(dependent));
        }

        private decimal PercentageDiscountForPerson(Person person)
        {
            if (PersonsNameStartsWithA(person))
            {
                return NameStartsWithADiscountPercentage;
            }
            return 0;
        }

        private bool PersonsNameStartsWithA(Person person)
        {
            return person.FirstName.ToLowerInvariant().StartsWith("a");
        }
    }
}