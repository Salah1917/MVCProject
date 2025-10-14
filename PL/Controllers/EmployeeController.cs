using BLL.DTO.Employee;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmployeeController(IEmployeeService employeeService, IWebHostEnvironment environment, ILogger<EmployeeController> logger) : Controller
    {
        #region Properties

        private readonly IEmployeeService EmployeeService = employeeService;
        private readonly IWebHostEnvironment _environment = environment;
        private readonly ILogger _logger = logger;

        #endregion

        #region Index

        [HttpGet]
        public IActionResult Index()
        {
            var Employees = EmployeeService.GetAllEmployees(false);

            return View(Employees);
        }

        #endregion
        
        #region Creeate

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = EmployeeService.CreateEmployee(employeeDTO);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Can Not Create Employee");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }

            return View(employeeDTO);

        }

        #endregion

        #region Retrieve

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Employee = EmployeeService.GetByEmployeeId(id);

            return Employee is null ? NotFound() : View(Employee);
        }

        #endregion

        #region Update

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var Employee = EmployeeService.GetByEmployeeId(id.Value);
            if (Employee is null)
                return NotFound();

            var EmployeeDto = new UpdatedEmployeeDTO()
            {
                Id = Employee.Id,
                Name = Employee.Name,
                Address = Employee.Address,
                Age = Employee.Age,
                Email = Employee.Email,
                PhoneNumber = Employee.PhoneNumber,
                IsActive = Employee.IsActive,
                HiringDate = Employee.HiringDate,
                Gender = Employee.Gender,
                EmployeeType = Employee.EmployeeType,
            };
            return View(EmployeeDto);
        }

        [HttpPost]
        public IActionResult Edit(UpdatedEmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid) return View(employeeDTO);
            try
            {
                int result = EmployeeService.UpdateEmployee(employeeDTO);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Can Not Update Employee");
                    return View(employeeDTO);
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeDTO);
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("Errorview", ex);
                }
            }
        }

        #endregion

        #region Delete

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            try
            {
                var Deleted = EmployeeService.DeleteEmployee(id);
                if (Deleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee can not be deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("Errorview", ex);
                }
            }
        }

        #endregion
    }
}
