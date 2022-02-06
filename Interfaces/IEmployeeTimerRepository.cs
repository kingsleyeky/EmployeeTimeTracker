using EmployeeTimeMonitor.Models;

namespace EmployeeTimeMonitor.Interfaces
{
    public interface IEmployeeTimerRepository
    {
        void ClockIn(Employee employeeClockInDetails);
        void ClockOut(Employee employeeClockOutDetails);
        List<Employee> GetAllEmployeeStatus();
    }
}
