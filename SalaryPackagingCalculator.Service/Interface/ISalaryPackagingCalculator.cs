using SalaryPackagingCalculator.Entities;

namespace SalaryPackagingCalculator.Service.Interface;

public interface ISalaryPackagingCalculator
{
    double CalculatePackagingLimit(Employee employee);
}