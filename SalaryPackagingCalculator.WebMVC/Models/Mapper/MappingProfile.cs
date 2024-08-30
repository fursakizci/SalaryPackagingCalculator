using AutoMapper;
using SalaryPackagingCalculator.Entities;

namespace SalaryPackagingCalculator.WebMVC.Models.Mapper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeeModel, Employee>();
        CreateMap<Employee, EmployeeModel>();
    }
}