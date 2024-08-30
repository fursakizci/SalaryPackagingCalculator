using SalaryPackagingCalculator.Entities.Enum;

namespace SalaryPackagingCalculator.WebMVC.Models;

public class EmployeeModel
{
    public CompanyType CompanyType { get; set; }
    public EmploymentType EmploymentType { get; set; }
    public double Salary { get; set; }
    public double HoursWorked { get; set; } 
    public bool IsEducated { get; set; }
}