namespace EmployeeTimeMonitor.Interfaces;
public interface IEmployeeTimerService
{
    void ClockIn(Employee employeeClockInDetails);
    List<Employee> GetAllEmployees();
    void ClockOut(Employee employeeClockOutDetails);
}
