using EmployeeTimeMonitor.Enums;
using EmployeeTimeMonitor.Interfaces;
using EmployeeTimeMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeTimeMonitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IEmployeeTimerService _employeeTimerService;

        public HomeController(ILogger<HomeController> logger, IEmployeeTimerService employeeTimerService)
        {
            _logger = logger;
            this._employeeTimerService = employeeTimerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
           var listOfEmployees = _employeeTimerService.GetAllEmployees();
            return View(listOfEmployees);
        }

        [HttpPost]
        public IActionResult Index(string employeeName, string status, int Id)
        {
            HttpContext.Session.SetString("EmployeeId", Id.ToString());
            HttpContext.Session.SetString("EmployeeName", employeeName);
            HttpContext.Session.SetString("EmployeeStatus", status.ToString());
            return RedirectToAction("PasscodeView");
        }


        [HttpGet]
        public IActionResult PasscodeView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PasscodeView(string PassCode)
        {
            if(PassCode != null)
            {
                HttpContext.Session.SetString("Passcode", PassCode);

                var employeeStatus = HttpContext.Session.GetString("EmployeeStatus");

                if(employeeStatus == "Working")
                {
                    return RedirectToAction("EndTimer");

                }
                else if(employeeStatus == "Out")
                {
                    return RedirectToAction("StartTimer");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult StartTimer()
        {
            return View();   
        }

        [HttpPost]
        public IActionResult StartTimer(string currentTime)
        {
            var employeeName = HttpContext.Session.GetString("EmployeeName");
            var passCode = HttpContext.Session.GetString("Passcode");

            if (employeeName != null && passCode != null)
            {
                var employeeClockInDetails = new Employee
                {
                    Name = employeeName,
                    Passcode = passCode,
                    ClockInTime = currentTime,
                    Status = EmployeStatus.Working
                };

                _employeeTimerService.ClockIn(employeeClockInDetails);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }

        public IActionResult GetEmployeeAttandanceRecord()
        {
            var listOfEmployeeRecord = _employeeTimerService.GetAllEmployees().AsQueryable();
            var query = from employee in listOfEmployeeRecord
                        select new Employee
                        {
                            Name = employee.Name, 
                            ClockInTime = employee.ClockInTime, 
                            ClockOutTime = employee.ClockOutTime
                        };
            var listRec = listOfEmployeeRecord.ToList();

            return View(listRec);
        }

        [HttpGet]
        public IActionResult EndTimer()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EndTimer(string endTime)
        {
            if(endTime != null)
            {
                var employeeId = HttpContext.Session.GetString("EmployeeId");
                var employeeName = HttpContext.Session.GetString("EmployeeName");
                var passCode = HttpContext.Session.GetString("Passcode");

                var employeeDetails = new Employee
                {
                    Id = Convert.ToInt32(employeeId),
                    Name = employeeName,
                   ClockOutTime = endTime,
                   Passcode = passCode,
                    Status = EmployeStatus.Out
                };

                _employeeTimerService.ClockOut(employeeDetails);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
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
}