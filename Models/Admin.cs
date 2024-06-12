namespace FinalProjectEMIAS_API.Models;

public partial class Admin
{
    public int? IdAdmin { get; set; }

    public string Surname { get; set; } = null!;

    public string NameAdm { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string EnterPassword { get; set; } = null!;
}
