using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalaryPackagingCalculator.Entities;
using SalaryPackagingCalculator.Service.Factory;
using SalaryPackagingCalculator.WebMVC.Models;

namespace SalaryPackagingCalculator.WebMVC.Controllers;

public class HomeController : Controller
{
    private readonly IMapper _mapper;

    public HomeController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult Calculate(EmployeeModel employeeModel)
    {
        var employee = _mapper.Map<Employee>(employeeModel);
        
        if (!ModelState.IsValid)
        {
            return View("Index", employee);
        }
        
        var strategy = SalaryPackagingCalculatorFactory.GetStrategy(employee.CompanyType);
        var packageLimit = strategy.CalculatePackagingLimit(employee);
        ViewBag.PackageLimit = packageLimit;
        return View("Index", employee);
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}