using EmployeeTimeMonitor.Interfaces;

namespace EmployeeTimeMonitor.Repository;
public class EmployeeTimerRepository : IEmployeeTimerRepository
{
    private readonly EmployeeTimerDBContext _context;
    public EmployeeTimerRepository(EmployeeTimerDBContext context)
    {
        this._context = context;
    }
    public void ClockIn(Employee employeeClockInDetails)
    {
        _context.EmployeeTimerRecord.Add(employeeClockInDetails);
        _context.SaveChanges();
    }

    public void ClockOut(Employee employeeClockOutDetails)
    {
       var clockoutdetails = _context.EmployeeTimerRecord.Where(p => p.Id == employeeClockOutDetails.Id).FirstOrDefault();
        
        if(clockoutdetails != null)
        {
            //_context.EmployeeTimerRecord.Update(employeeClockOutDetails);
            // clockoutdetails = Microsoft.EntityFrameworkCore.EntityState.Modified;

            clockoutdetails.ClockOutTime = employeeClockOutDetails.ClockOutTime;
            clockoutdetails.Status = employeeClockOutDetails.Status;

            _context.SaveChanges();
        }
    }

    public List<Employee> GetAllEmployeeStatus()
    {
       // var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
        var listOfEmployees = _context.EmployeeTimerRecord.Select(e => new Employee
        {
            Id = e.Id,
            Name = e.Name,
            Status = e.Status,
            Date_Stamp = e.Date_Stamp,
            ClockOutTime = e.ClockOutTime,
            ClockInTime = e.ClockInTime
        }).Where(x => x.Date_Stamp >= DateTime.Today.Date ).ToList();

        return listOfEmployees;
    }
}
