using SalaryPackagingCalculator.Entities.Enum;
using SalaryPackagingCalculator.Service.Interface;

namespace SalaryPackagingCalculator.Service.Factory;

public class SalaryPackagingCalculatorFactory
{
    public static ISalaryPackagingCalculator GetStrategy(CompanyType companyType)
    {
        return companyType switch
        {
            CompanyType.Corporate => new CorporateSalaryPackagingCalculator(),
            CompanyType.Hospital => new HospitalSalaryPackagingCalculator(),
            CompanyType.PBI => new PBISalaryPackagingCalculator(),
            _ => throw new ArgumentException("Invalid Company Type")
        };
    }
}