using EmployeeTimeMonitor.Interfaces;

namespace EmployeeTimeMonitor.Services;

public class EmployeeTimerService : IEmployeeTimerService
{
    private readonly IEmployeeTimerRepository _employeeTimerRepository;
    public EmployeeTimerService(IEmployeeTimerRepository employeeTimerRepository)
    {
        this._employeeTimerRepository = employeeTimerRepository;    
    }
    public void ClockIn(Employee employeeClockInDetails)
    {
        if(employeeClockInDetails != null)
            _employeeTimerRepository.ClockIn(employeeClockInDetails);
    }

    public void ClockOut(Employee employeeClockOutDetails)
    {
        if(employeeClockOutDetails != null)
            _employeeTimerRepository.ClockOut(employeeClockOutDetails);
    }

    public List<Employee> GetAllEmployees()
    {
       var listOfEmployees = _employeeTimerRepository.GetAllEmployeeStatus();
        return listOfEmployees;
    }

    public void ClockOut()
    {
        throw new NotImplementedException();
    }
}

