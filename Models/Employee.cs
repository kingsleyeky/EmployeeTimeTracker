using EmployeeTimeMonitor.Enums;

namespace EmployeeTimeMonitor.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Passcode { get; set; }
        public string? ClockInTime { get; set; }
        public string? ClockOutTime { get; set; }
        public EmployeStatus Status { get; set; }

        public DateTime Date_Stamp { get; set; } = DateTime.Today;
    }
}

