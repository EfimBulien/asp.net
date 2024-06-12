namespace FinalProjectEMIAS_API.Models;

public partial class Patient
{
    public long? Oms { get; set; }

    public string SurnameP { get; set; } = null!;

    public string NameP { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateTime BirthDate { get; set; }

    public string AddressP { get; set; } = null!;

    public string? LivingAddress { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? NameOfOms { get; set; }
}
