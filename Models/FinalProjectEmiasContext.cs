using Microsoft.EntityFrameworkCore;

namespace FinalProjectEMIAS_API.Models;

public partial class FinalProjectEmiasContext : DbContext
{
    public FinalProjectEmiasContext()
    {
    }

    public FinalProjectEmiasContext(DbContextOptions<FinalProjectEmiasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AnalysDocument> AnalysDocuments { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentDocument> AppointmentDocuments { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<ResearchDocument> ResearchDocuments { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__Admins__69F567663375737A");

            entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");
            entity.Property(e => e.EnterPassword).HasMaxLength(50);
            entity.Property(e => e.NameAdm).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<AnalysDocument>(entity =>
        {
            entity.HasKey(e => e.IdAnalysDocument).HasName("PK__AnalysDo__11B9576478B65C59");

            entity.ToTable("AnalysDocument");

            entity.HasIndex(e => e.AppointmentId, "UQ__AnalysDo__FD01B5022CE951A0").IsUnique();

            entity.Property(e => e.IdAnalysDocument).HasColumnName("ID_AnalysDocument");
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__Appointm__CE24CCCC0C8343AD");

            entity.Property(e => e.IdAppointment).HasColumnName("ID_Appointment");
            entity.Property(e => e.AppointmentDate).HasColumnType("date");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");
            entity.Property(e => e.Oms).HasColumnName("OMS");
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");
        });

        modelBuilder.Entity<AppointmentDocument>(entity =>
        {
            entity.HasKey(e => e.IdAppointmentDocument).HasName("PK__Appointm__077DCD83953A378E");

            entity.ToTable("AppointmentDocument");

            entity.HasIndex(e => e.AppointmentId, "UQ__Appointm__FD01B50235248C6C").IsUnique();

            entity.Property(e => e.IdAppointmentDocument).HasColumnName("ID_AppointmentDocument");
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.IdDirection).HasName("PK__Directio__59A79AAF5C72159D");

            entity.Property(e => e.IdDirection).HasColumnName("ID_Direction");
            entity.Property(e => e.Oms).HasColumnName("OMS");
            entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PK__Doctors__3246951CE01C2333");

            entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");
            entity.Property(e => e.EnterPassword).HasMaxLength(50);
            entity.Property(e => e.NameDoc).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");
            entity.Property(e => e.SurnameDoc).HasMaxLength(50);
            entity.Property(e => e.WorkAddress).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Oms).HasName("PK__Patients__CB396B8BA946475A");

            entity.Property(e => e.Oms)
                .ValueGeneratedNever()
                .HasColumnName("OMS");
            entity.Property(e => e.AddressP).HasMaxLength(255);
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LivingAddress).HasMaxLength(255);
            entity.Property(e => e.NameOfOms)
                .HasMaxLength(50)
                .HasColumnName("NameOfOMS");
            entity.Property(e => e.NameP).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(18);
            entity.Property(e => e.SurnameP).HasMaxLength(50);
        });

        modelBuilder.Entity<ResearchDocument>(entity =>
        {
            entity.HasKey(e => e.IdResearchDocument).HasName("PK__Research__117811C65A8DA973");

            entity.ToTable("ResearchDocument");

            entity.HasIndex(e => e.AppointmentId, "UQ__Research__FD01B502732D959D").IsUnique();

            entity.Property(e => e.IdResearchDocument).HasColumnName("ID_ResearchDocument");
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");
            entity.Property(e => e.Attachment)
                .HasMaxLength(1)
                .IsFixedLength();
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.IdSpeciality).HasName("PK__Speciali__8D22304DF942F8FD");

            entity.Property(e => e.IdSpeciality).HasColumnName("ID_Speciality");
            entity.Property(e => e.NameSp).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__Statuses__5AC2A7342AB71F38");

            entity.Property(e => e.IdStatus).HasColumnName("ID_Status");
            entity.Property(e => e.NameSt).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
