using SalaryPackagingCalculator.Entities;
using SalaryPackagingCalculator.Entities.Enum;
using SalaryPackagingCalculator.Service.Interface;

namespace SalaryPackagingCalculator.Service;

public class PBISalaryPackagingCalculator : ISalaryPackagingCalculator
{
    private const double MaxFlatAmount = 50000;
    private const double SalaryPercentageLimit = 0.3255;
    private const double CasualLimitPercentage = 0.1;
    private const double PartTimeMultiplier = 0.8;
    private const double EducationBonus = 2000;
    private const double EducationBonusPercentage = 0.01;

    public double CalculatePackagingLimit(Employee employee)
    {
        var baseLimit = Math.Min(MaxFlatAmount, employee.Salary * SalaryPercentageLimit);

        if (employee.EmploymentType == EmploymentType.Casual)
        {
            baseLimit = employee.Salary * CasualLimitPercentage;
        }
        
        else if (employee.EmploymentType == EmploymentType.PartTime)
        {
            baseLimit *= PartTimeMultiplier;
        }
        
        if (employee.IsEducated)
        {
            baseLimit += EducationBonus + (employee.Salary * EducationBonusPercentage);
        }

        return baseLimit;
    }
}