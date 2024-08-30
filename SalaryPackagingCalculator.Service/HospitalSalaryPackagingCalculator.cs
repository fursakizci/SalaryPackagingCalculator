using SalaryPackagingCalculator.Entities;
using SalaryPackagingCalculator.Entities.Enum;
using SalaryPackagingCalculator.Service.Interface;

namespace SalaryPackagingCalculator.Service;

public class HospitalSalaryPackagingCalculator : ISalaryPackagingCalculator
{
    private const double FlatAmount = 10000;
    private const double SalaryPercentageLimit = 0.2;
    private const double MaxSalaryLimit = 30000;
    private const double EducationBonus = 5000;
    private const double FullTimeMultiplier = 1.095;
    private const double AdditionalSalaryPercentage = 0.012;

    public double CalculatePackagingLimit(Employee employee)
    {
        var baseLimit = Math.Max(FlatAmount, employee.Salary * SalaryPercentageLimit);
        baseLimit = Math.Min(baseLimit, MaxSalaryLimit);

        if (employee.IsEducated)
        {
            baseLimit += EducationBonus;
        }

        if (employee.EmploymentType == EmploymentType.FullTime)
        {
            baseLimit *= FullTimeMultiplier;
            baseLimit += employee.Salary * AdditionalSalaryPercentage;
        }

        return baseLimit;
    }
}