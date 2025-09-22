using BLL.DTO;
using BLL.DTO.Department;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels.DepartmentViewModels;

namespace PL.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService, ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller()
    {
        #region Properties
        
        private readonly IDepartmentService departmentService = _departmentService;
        private readonly ILogger<DepartmentController> logger = _logger;
        private readonly IWebHostEnvironment environment = _environment;

        #endregion

        #region Index

        [HttpGet]
        public IActionResult Index()
        {
            var departments = departmentService.GetAllDepartments();

            return View(departments);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDTO departmentDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = departmentService.AddDepartment(departmentDTO);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department cannot be created");
                        //return View(departmentDTO);
                    }
                }
                catch (Exception ex)
                {
                    //Development
                    if (environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        //return View(departmentDTO);
                    }

                    //Deployment
                    else
                    {
                        logger.LogError(ex.Message);
                        //return View(departmentDTO);
                    }
                }
            }
            return View(departmentDTO);

        }
        #endregion

        #region Retrieve

        [HttpGet]
        public IActionResult Details(int? id)
        {
            //return a bad request if there is no id value
            if (!id.HasValue)
                return BadRequest();
            
            //retrieve department from database
            var Department = departmentService.GetDepartmentByID(id.Value);
            
            //return 400 if it doesn't exist
            if (Department is null)
                return NotFound();

            //return the department if all is well
            return View(Department);
        }


        #endregion

        #region Update

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //return a bad request if there is no id value
            if (!id.HasValue)
                return BadRequest();

            //retrieve department from database
            var Department = departmentService.GetDepartmentByID(id.Value);

            //return 400 if it doesn't exist
            if (Department is null)
                return NotFound();

            var DepartmentViewModel = new DepartmentEditViewModel()
            {
                Code = Department.Code,
                Name = Department.Name,
                Description = Department.Description,
                DateOfCreation = Department.DateOfCreation,
            };

            //return the department if all is well
            return View(DepartmentViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int? id, DepartmentEditViewModel DepartmentViewModel)
        {
            if (!ModelState.IsValid)
                return View(DepartmentViewModel);
            try
            {
                var updatedDepartment = new UpdatedDepartmentDTO()
                {
                    Id = id.Value,
                    Name = DepartmentViewModel.Name,
                    Code = DepartmentViewModel.Code,
                    Description = DepartmentViewModel.Description,
                    DateOfCreation = DepartmentViewModel.DateOfCreation
                };

                int result = departmentService.UpdateDepartment(updatedDepartment);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department cannot be edited");
                    return View(DepartmentViewModel);
                }
            }
            catch (Exception ex)
            {
                //Development
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(DepartmentViewModel);
                }

                //Deployment
                else
                {
                    logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }
        }

        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //return a bad request if there is no id value
            if (!id.HasValue)
                return BadRequest();

            //retrieve department from database
            var Department = departmentService.GetDepartmentByID(id.Value);

            //return 400 if it doesn't exist
            if (Department is null)
                return NotFound();

            //return the department if all is well
            return View(Department);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            try
            {
                bool Deleted = departmentService.DeleteDepartment(id);
                if (Deleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Department was not deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                //Development
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }

                //Deployment
                else
                {
                    logger.LogError(ex.Message);
                    return RedirectToAction("ErrorView", ex.Message);
                }
            }
        }

        #endregion
    }
}
