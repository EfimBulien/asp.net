namespace FinalProjectEMIAS_API.Models;

public partial class Doctor
{
    public int? IdDoctor { get; set; }

    public string SurnameDoc { get; set; } = null!;

    public string NameDoc { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int SpecialityId { get; set; }

    public string EnterPassword { get; set; } = null!;

    public string WorkAddress { get; set; } = null!;
}
