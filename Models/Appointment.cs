namespace FinalProjectEMIAS_API.Models;

public partial class Appointment
{
    public int? IdAppointment { get; set; }

    public int DoctorId { get; set; }

    public long Oms { get; set; }

    public DateTime AppointmentDate { get; set; }

    public TimeSpan AppointmentTime { get; set; }

    public int StatusId { get; set; }
}
