using FluentValidation;

namespace SalaryPackagingCalculator.WebMVC.Models.Validation;

public class EmployeeModelValidator:AbstractValidator<EmployeeModel>
{
    public EmployeeModelValidator()
    {
        RuleFor(x => x.CompanyType)
            .IsInEnum().WithMessage("Company Type is required.");

        RuleFor(x => x.EmploymentType)
            .IsInEnum().WithMessage("Employment Type is required.");

        RuleFor(x => x.Salary)
            .GreaterThan(0).WithMessage("Salary must be greater than 0.");

    }
}