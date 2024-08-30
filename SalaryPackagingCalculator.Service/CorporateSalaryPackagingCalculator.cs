using SalaryPackagingCalculator.Entities;
using SalaryPackagingCalculator.Entities.Enum;
using SalaryPackagingCalculator.Service.Interface;

namespace SalaryPackagingCalculator.Service;

public class CorporateSalaryPackagingCalculator : ISalaryPackagingCalculator
{
    private const double FirstLimitPercentage = 0.01;
    private const double SecondLimitPercentage = 0.001;
    private const double MaxFirstLimit = 100000;
    private const double FullTimeHours = 38;

    public double CalculatePackagingLimit(Employee employee)
    {
        if (employee.EmploymentType == EmploymentType.Casual)
        {
            return 0;
        }

        var limit = employee.Salary <= MaxFirstLimit
            ? employee.Salary * FirstLimitPercentage
            : MaxFirstLimit * FirstLimitPercentage + (employee.Salary - MaxFirstLimit) * SecondLimitPercentage;

        if (employee.EmploymentType == EmploymentType.PartTime)
        {
            var hoursWorkedPercentage = employee.HoursWorked / FullTimeHours;
            limit *= Math.Min(hoursWorkedPercentage, 1.0);
        }

        return limit;
    }
}