namespace FinalProjectEMIAS_API.Models;

public partial class AppointmentDocument
{
    public int? IdAppointmentDocument { get; set; }

    public int? AppointmentId { get; set; }

    public string Rtf { get; set; } = null!;
}
