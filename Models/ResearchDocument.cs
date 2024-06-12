namespace FinalProjectEMIAS_API.Models;

public partial class ResearchDocument
{
    public int? IdResearchDocument { get; set; }

    public int? AppointmentId { get; set; }

    public string Rtf { get; set; } = null!;

    public byte[]? Attachment { get; set; }
}
