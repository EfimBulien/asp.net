namespace FinalProjectEMIAS_API.Models;

public partial class AnalysDocument
{
    public int? IdAnalysDocument { get; set; }

    public int? AppointmentId { get; set; }

    public string Rtf { get; set; } = null!;
}
