using System.Linq;
using Paylocity.Models;

namespace Paylocity.Services
{
    public class BenefitsCalculator
    {
        private const decimal CostForEmployee = 1000M;
        private const decimal CostForDependent = 500M;
        private const decimal NameStartsWithADiscountPercentage = .10M;

        public decimal CostOfBenefits(Employee employee)
        {
            var employeeCost = CostForEmployee - GetDiscountForEmployee(employee);
            var dependentCost = CostForDependent * employee.Dependents.Count() - TotalDependentsDiscount(employee);
            return employeeCost + dependentCost;
        }

        private decimal GetDiscountForEmployee(Employee employee)
        {
            if (PersonsNameStartsWithA(employee))
            {
                return CostForEmployee * NameStartsWithADiscountPercentage;
            }
            return 0;
        }

        private decimal TotalDependentsDiscount(Employee employee)
        {
            return employee.Dependents.Sum(dependent => DiscountForDependent(dependent));
        }

        private static decimal DiscountForDependent(Person person)
        {
            var qualifies = PersonsNameStartsWithA(person);
            return qualifies ? NameStartsWithADiscountPercentage * CostForDependent : 0;
        }

        private static bool PersonsNameStartsWithA(Person person)
        {
            return person.FirstName.ToLowerInvariant().StartsWith("a");
        }
    }
}