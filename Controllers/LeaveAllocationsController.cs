//using AutoMapper;
//using LMS_Backend.Contracts;
//using LMS_Backend.Data;
//using LMS_Backend.Models;
////using LMS_Backend.Data.Migrations;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//namespace LMS_Backend.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]

//    public class LeaveAllocationController : Controller
//    {
//        private readonly ILeaveTypeRepository _leaveRepo;
//        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
//        private readonly IMapper _mapper;
//        private readonly UserManager<Employee> _userManager;

//        public LeaveAllocationController(
//            ILeaveTypeRepository leaveRepo,
//            ILeaveAllocationRepository leaveAllocationRepo,
//            IMapper mapper,
//            UserManager<Employee> userManager
//        )
//        {
//            _leaveRepo = leaveRepo;
//            _leaveAllocationRepo = leaveAllocationRepo;
//            _mapper = mapper;
//            _userManager = userManager;
//        }

//        // GET: LeaveAllocationController
//        public ActionResult Index()
//        {
//            var leavetypes = _leaveRepo.FindAll().ToList();
//            var mappedLeaveTypes = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leavetypes);
//            var model = new CreateLeaveAllocationVM
//            {
//                LeaveTypes = mappedLeaveTypes,
//                NumberUpdated = 0
//            };
//            return View(model);
//        }

//        public ActionResult SetLeave(int id)
//        {
//            var leaveType = _leaveRepo.FindById(id);
//            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
//            foreach (var emp in employees)
//            {
//                if (_leaveAllocationRepo.CheckAllocation(id, emp.Id))
//                {
//                    continue;
//                }
//                var allocation = new LeaveAllocationVM
//                {
//                    DateCreated = DateTime.Now,
//                    EmployeeId = emp.Id,
//                    LeaveTypeId = id,
//                    NumberOfDays = leaveType.DefaultDays,
//                    Period = DateTime.Now.Year
//                };
//                var leaveallocation = _mapper.Map<LeaveAllocation>(allocation);
//                _leaveAllocationRepo.Create(leaveallocation);
//            }
//            return RedirectToAction(nameof(Index));
//        }
//        [HttpGet]
//        public ActionResult ListEmployees()
//        {
//            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
//            var model = _mapper.Map<List<EmployeeVM>>(employees);
//            return View(model);
//        }

//        // GET: LeaveAllocationController/Details/5
//        public ActionResult Details(string id)
//        {
//            var employee = _mapper.Map<EmployeeVM>(_userManager.FindByIdAsync(id).Result);
//            var allocations = _mapper.Map<List<LeaveAllocationVM>>
//                (_leaveAllocationRepo.GetLeaveAllocationsByEmployee(id));
//            var model = new ViewLeaveAllocationVM
//            {
//                Employee = employee,
//                LeaveAllocations = allocations
//            };
//            return View(model);
//        }

//        // GET: LeaveAllocationController/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: LeaveAllocationController/Create
//        [HttpPost]

//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: LeaveAllocationController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            var leaveAllocation = _leaveAllocationRepo.FindById(id);
//            var model = _mapper.Map<EditLeaveAllocationVM>(leaveAllocation);
//            return View(model);
//        }

//        // POST: LeaveAllocationController/Edit/5
//        [HttpPost]

//        public ActionResult Edit(EditLeaveAllocationVM model)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                {
//                    return View(model);
//                }
//                var record = _leaveAllocationRepo.FindById(model.Id);
//                record.NumberOfDays = model.NumberOfDays;
//                var isSuccess = _leaveAllocationRepo.Update(record);
//                if (!isSuccess)
//                {
//                    ModelState.AddModelError("", "Error while savng");
//                    return View(model);
//                }
//                return RedirectToAction(nameof(Details), new { id = model.EmployeeId });
//            }
//            catch
//            {
//                return View(model);
//            }
//        }

//        // GET: LeaveAllocationController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: LeaveAllocationController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
using LMS_Backend.Contracts;
using LMS_Backend.Data;
using LMS_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace LMS_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly DataContext dataContext_;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public LeaveAllocationController(DataContext dataContext, ILeaveAllocationRepository leaveAllocationRepository)
        {
            dataContext_ = dataContext;
            _leaveAllocationRepository = leaveAllocationRepository;

        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveAllocation>>> GetLeaveAllocations()
        {
            try
            {
                var leaveAllocations = await Task.Run(() => _leaveAllocationRepository.FindAll().ToList());
                return Ok(leaveAllocations);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<LeaveAllocation>>> SetLeaveAllocations(int leaveTypeId, DateTime date, int numberOfDays, int period, int employeeId)
        {
            try
            {
                var leaveAllocations = await Task.Run(() => _leaveAllocationRepository.FindAll().ToList());

                var newLeaveAllocation = new LeaveAllocation
                {
                    DateCreated = date.ToUniversalTime(),
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveTypeId,
                    NumberOfDays = numberOfDays,
                    Period = period
                    // Set other properties based on your model
                };

                await Task.Run(() => _leaveAllocationRepository.Create(newLeaveAllocation));

                leaveAllocations.Add(newLeaveAllocation);

                return Ok(leaveAllocations);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaveAllocation(int id, int leaveTypeId, DateTime date, int numberOfDays, int period, int employeeId)
        {
            try
            {
                var leaveAllocations = await Task.Run(() => _leaveAllocationRepository.FindAll().ToList());
                var leaveAllocationToUpdate = leaveAllocations.FirstOrDefault(allocation => allocation.Id == id);

                if (leaveAllocationToUpdate == null)
                {
                    return NotFound();
                }

                leaveAllocationToUpdate.DateCreated = date.ToUniversalTime();
                leaveAllocationToUpdate.EmployeeId = employeeId;
                leaveAllocationToUpdate.LeaveTypeId = leaveTypeId;
                leaveAllocationToUpdate.NumberOfDays = numberOfDays;
                leaveAllocationToUpdate.Period = period;

                await Task.Run(() => _leaveAllocationRepository.Update(leaveAllocationToUpdate));

                return Ok(leaveAllocations);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveAllocation(int id)
        {
            try
            {
                var leaveAllocations = await Task.Run(() => _leaveAllocationRepository.FindAll().ToList());
                var leaveAllocationToDelete = leaveAllocations.FirstOrDefault(allocation => allocation.Id == id);

                if (leaveAllocationToDelete == null)
                {
                    return NotFound();
                }

                await Task.Run(() => _leaveAllocationRepository.Delete(leaveAllocationToDelete));

                return Ok(leaveAllocations);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocation>> GetLeaveAllocation(int id)
        {
            try
            {
                var leaveAllocations = await Task.Run(() => _leaveAllocationRepository.FindAll().ToList());
                var leaveAllocation = leaveAllocations.FirstOrDefault(allocation => allocation.Id == id);

                if (leaveAllocation == null)
                {
                    return NotFound();
                }

                return Ok(leaveAllocation);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
