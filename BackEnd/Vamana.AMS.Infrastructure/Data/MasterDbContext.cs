using Microsoft.EntityFrameworkCore;
using Vamana.AMS.Core.Entities.Masters;

namespace Vamana.AMS.Infrastructure.Data;

public class MasterDbContext : DbContext
{
    public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options) { }

    public DbSet<CategoryMaster> Categories { get; set; }
    public DbSet<CasteMaster> Castes { get; set; }
    public DbSet<ReceiptTypeMaster> ReceiptTypeMasters { get; set; }
    public DbSet<ReceiptCodeMaster> ReceiptCodeMasters { get; set; }
    public DbSet<ReceiptBelongsToMaster> ReceiptBelongsToMasters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdmissionBatchMaster>().ToTable("AdmissionBatchMaster");
        modelBuilder.Entity<AdmissionBatchMaster>().HasKey(r => r.AdmissionBatchId);

        modelBuilder.Entity<AdmissionCategoryMaster>().ToTable("AdmissionCategoryMaster");
        modelBuilder.Entity<AdmissionCategoryMaster>().HasKey(r => r.AdmissionCategoryId);

        modelBuilder.Entity<AdmissionThroughMaster>().ToTable("AdmissionThroughMaster");
        modelBuilder.Entity<AdmissionThroughMaster>().HasKey(r => r.AdmissionThroughId);

        modelBuilder.Entity<AdmissionTypeMaster>().ToTable("AdmissionTypeMaster");
        modelBuilder.Entity<AdmissionTypeMaster>().HasKey(r => r.AdmissionTypeId);

        modelBuilder.Entity<AdmissionYearMaster>().ToTable("AdmissionYearMaster");
        modelBuilder.Entity<AdmissionYearMaster>().HasKey(r => r.AdmissionYearId);

        modelBuilder.Entity<BloodGroupMaster>().ToTable("BloodGroupMaster");
        modelBuilder.Entity<BloodGroupMaster>().HasKey(r => r.BloodGroupId);

        modelBuilder.Entity<BranchMaster>().ToTable("BranchMaster");
        modelBuilder.Entity<BranchMaster>().HasKey(r => r.BranchId);

        modelBuilder.Entity<CategoryMaster>().ToTable("CategoryMaster");
        modelBuilder.Entity<CategoryMaster>().HasKey(c => c.CategoryId);

        modelBuilder.Entity<CasteMaster>().ToTable("CasteMaster");
        modelBuilder.Entity<CasteMaster>().HasKey(c => c.CasteId);
        modelBuilder.Entity<CasteMaster>()
            .HasOne(c => c.Category)
            .WithMany(cat => cat.Castes)
            .HasForeignKey(c => c.CategoryId);


        //modelBuilder.Entity<CountryMaster>().ToTable("CountryMaster");
        //modelBuilder.Entity<CountryMaster>().HasKey(c => c.CountryId);

        //modelBuilder.Entity<StateMaster>().ToTable("StateMaster");
        //modelBuilder.Entity<StateMaster>().HasKey(c => c.StateId);
        //modelBuilder.Entity<StateMaster>()
        //   .HasOne(c => c.Country)
        //   .WithMany(con => con.States)
        //   .HasForeignKey(c => c.CountryId);

        //modelBuilder.Entity<DistrictMaster>().ToTable("DistrictMaster");
        //modelBuilder.Entity<DistrictMaster>().HasKey(c => c.DistrictId);
        //modelBuilder.Entity<DistrictMaster>()
        //   .HasOne(c => c.State)
        //   .WithMany(s => s.ci)
        //   .HasForeignKey(c => c.CountryId);

        modelBuilder.Entity<CountryMaster>(entity =>
        {
            entity.ToTable("CountryMaster");

            entity.HasKey(e => e.CountryId);

            entity.Property(e => e.CountryId)
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.CountryName)
                  .IsRequired()
                  .HasMaxLength(100);

            //entity.HasMany(e => e.States)
            //      .WithOne(s => s.Country)
            //      .HasForeignKey(s => s.CountryId)
            //      .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<StateMaster>(entity =>
        {
            entity.ToTable("StateMaster");

            entity.HasKey(e => e.StateId);

            entity.Property(e => e.StateId)
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.StateName)
                  .IsRequired()
                  .HasMaxLength(100);

            //entity.HasOne(e => e.Country)
            //      .WithMany(c => c.States)
            //      .HasForeignKey(e => e.CountryId)
            //      .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.Districts)
                  .WithOne(d => d.State)
                  .HasForeignKey(d => d.StateId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<DistrictMaster>(entity =>
        {
            entity.ToTable("DistrictMaster");

            entity.HasKey(e => e.DistrictId);

            entity.Property(e => e.DistrictId)
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.DistrictName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasOne(e => e.State)
                  .WithMany(s => s.Districts)
                  .HasForeignKey(e => e.StateId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.Cities)
                  .WithOne(c => c.District)
                  .HasForeignKey(c => c.DistrictId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<CityMaster>(entity =>
        {
            entity.ToTable("CityMaster");

            entity.HasKey(e => e.CityId);

            entity.Property(e => e.CityId)
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.CityName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasOne(e => e.District)
                  .WithMany(d => d.Cities)
                  .HasForeignKey(e => e.DistrictId)
                  .OnDelete(DeleteBehavior.Restrict);

            //entity.HasOne(e => e.State)
            //      .WithMany()
            //      .HasForeignKey(e => e.StateId)
            //      .OnDelete(DeleteBehavior.Restrict);
        });


        modelBuilder.Entity<GenderMaster>().ToTable("GenderMaster");
        modelBuilder.Entity<GenderMaster>().HasKey(c => c.GenderId);

        modelBuilder.Entity<InstituteMaster>().ToTable("InstituteMaster");
        modelBuilder.Entity<InstituteMaster>().HasKey(c => c.InstituteId);

        modelBuilder.Entity<NationalityMaster>().ToTable("NationalityMaster");
        modelBuilder.Entity<NationalityMaster>().HasKey(n => n.NationalityId);

        modelBuilder.Entity<PaymentTypeMaster>().ToTable("PaymentTypeMaster");
        modelBuilder.Entity<PaymentTypeMaster>().HasKey(n => n.PaymentTypeId);



        modelBuilder.Entity<ReceiptTypeMaster>().ToTable("ReceiptTypeMaster");
        modelBuilder.Entity<ReceiptTypeMaster>().HasKey(n => n.ReceiptTypeId);

        modelBuilder.Entity<ReceiptCodeMaster>().ToTable("ReceiptCodeMaster");
        modelBuilder.Entity<ReceiptCodeMaster>().HasKey(n => n.ReceiptCodeId);

        modelBuilder.Entity<ReceiptBelongsToMaster>().ToTable("ReceiptBelongsToMaster");
        modelBuilder.Entity<ReceiptBelongsToMaster>().HasKey(n => n.ReceiptBelongsToId);

        // ReceiptTypeMaster configuration
        modelBuilder.Entity<ReceiptTypeMaster>(entity =>
        {
            entity.HasKey(e => e.ReceiptTypeId);

            entity.Property(e => e.ReceiptTypeName)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.AccountNo)
                  .HasMaxLength(50);

            // Relationships
            entity.HasOne(e => e.ReceiptCodeMaster)
                  .WithMany(rc => rc.ReceiptTypeMasters)
            .HasForeignKey(e => e.ReceiptCodeId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.ReceiptBelongsToMaster)
                  .WithMany(rb => rb.ReceiptTypeMasters)
                  .HasForeignKey(e => e.ReceiptBelongsTo)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // ReceiptCodeMaster configuration
        modelBuilder.Entity<ReceiptCodeMaster>(entity =>
        {
            entity.HasKey(e => e.ReceiptCodeId);

            entity.Property(e => e.ReceiptCodeName)
                  .IsRequired()
                  .HasMaxLength(200);
        });

        // ReceiptBelongsToMaster configuration
        modelBuilder.Entity<ReceiptBelongsToMaster>(entity =>
        {
            entity.HasKey(e => e.ReceiptBelongsToId);

            entity.Property(e => e.ReceiptBelongsToName)
                  .IsRequired()
                  .HasMaxLength(200);
        });

        modelBuilder.Entity<ScholarshipModeMaster>().ToTable("ScholarshipModeMaster");
        modelBuilder.Entity<ScholarshipModeMaster>().HasKey(n => n.ScholarshipModeId);

        modelBuilder.Entity<ScholarshipTypeMaster>().ToTable("ScholarshipTypeMaster");
        modelBuilder.Entity<ScholarshipTypeMaster>().HasKey(n => n.ScholarshipTypeId);

        modelBuilder.Entity<DegreeMaster>().ToTable("DegreeMaster");
        modelBuilder.Entity<DegreeMaster>().HasKey(c => c.DegreeId);

        modelBuilder.Entity<ReligionMaster>().ToTable("ReligionMaster");
        modelBuilder.Entity<ReligionMaster>().HasKey(r => r.ReligionId);

        modelBuilder.Entity<BloodGroupMaster>().ToTable("BloodGroupMaster");
        modelBuilder.Entity<BloodGroupMaster>().HasKey(r => r.BloodGroupId);

        modelBuilder.Entity<SemesterMaster>().ToTable("SemesterMaster");
        modelBuilder.Entity<SemesterMaster>().HasKey(r => r.SemesterId);

        modelBuilder.Entity<SessionMaster>().ToTable("SessionMaster");
        modelBuilder.Entity<SessionMaster>().HasKey(r => r.SessionId);

        modelBuilder.Entity<InstallmentTypeMaster>().ToTable("InstallmentTypeMaster");
        modelBuilder.Entity<InstallmentTypeMaster>().HasKey(r => r.InstallmentTypeId);

        //modelBuilder.Entity<CountryMaster>().ToTable("CountryMaster");
        //modelBuilder.Entity<CountryMaster>().HasKey(r => r.CountryId);

        //modelBuilder.Entity<StateMaster>().ToTable("StateMaster");
        //modelBuilder.Entity<StateMaster>().HasKey(c => c.StateId);
        //modelBuilder.Entity<StateMaster>()
        //    .HasOne(c => c.Country)
        //    .WithMany(s => s.States)
        //    .HasForeignKey(c => c.CountryId);


    }

}
