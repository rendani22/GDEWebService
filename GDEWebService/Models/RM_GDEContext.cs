using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GDEWebService.Models
{
    public partial class RM_GDEContext : DbContext
    {
        public RM_GDEContext()
        {
        }

        public RM_GDEContext(DbContextOptions<RM_GDEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CandidateScriptInfomation> CandidateScriptInfomation { get; set; }
        public virtual DbSet<Candidates> Candidates { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Markers> Markers { get; set; }
        public virtual DbSet<NewCandidates> NewCandidates { get; set; }
        public virtual DbSet<Packets> Packets { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<QuestionPaper> QuestionPaper { get; set; }
        public virtual DbSet<Session> Session { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=156.38.161.170,1433;Database=RM_GDE;User Id=sa;Password=Laser2020; Trusted_Connection=True; Integrated Security=false;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateScriptInfomation>(entity =>
            {
                entity.ToTable("candidateScriptInfomation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CandidateExamNumber)
                    .IsRequired()
                    .HasColumnName("candidateExamNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(1850);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasColumnName("subjectCode")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Candidates>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Candidate)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CentreName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CircName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DistrName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Emis)
                    .IsRequired()
                    .HasColumnName("EMIS")
                    .HasMaxLength(150);

                entity.Property(e => e.ExamPeriod)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ExamType)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ExamTypeName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Idno)
                    .IsRequired()
                    .HasColumnName("IDNo")
                    .HasMaxLength(150);

                entity.Property(e => e.MsNo)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Paper)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PaperDesc)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PaperDuration).HasMaxLength(150);

                entity.Property(e => e.PaperMax)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PaperTime)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PaperType)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Prov)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ProvName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.RegName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.ExamId).HasColumnName("examID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartDatePart).HasMaxLength(50);
            });

            modelBuilder.Entity<Markers>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AcademicQualification)
                    .HasColumnName("Academic_Qualification")
                    .HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.Address3).HasMaxLength(50);

                entity.Property(e => e.Cellphone).HasMaxLength(50);

                entity.Property(e => e.CentreName)
                    .IsRequired()
                    .HasColumnName("Centre_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Comments).HasMaxLength(100);

                entity.Property(e => e.Districts)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Duty)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EMail)
                    .HasColumnName("e_mail")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Grade12TeachingExperience)
                    .HasColumnName("Grade_12_teaching_experience")
                    .HasMaxLength(50);

                entity.Property(e => e.HighestLevelInSubject)
                    .HasColumnName("Highest_level_in_Subject")
                    .HasMaxLength(50);

                entity.Property(e => e.HomeTel)
                    .HasColumnName("Home_Tel")
                    .HasMaxLength(50);

                entity.Property(e => e.IdNo)
                    .IsRequired()
                    .HasColumnName("ID_No")
                    .HasMaxLength(50);

                entity.Property(e => e.MarkingExp)
                    .HasColumnName("Marking_Exp")
                    .HasMaxLength(50);

                entity.Property(e => e.MeetsCriteria)
                    .HasColumnName("Meets_Criteria")
                    .HasMaxLength(50);

                entity.Property(e => e.Motivation).HasMaxLength(50);

                entity.Property(e => e.PCode)
                    .HasColumnName("P_Code")
                    .HasMaxLength(50);

                entity.Property(e => e.Paper)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pass).HasMaxLength(50);

                entity.Property(e => e.PersalNo)
                    .IsRequired()
                    .HasColumnName("Persal_No")
                    .HasMaxLength(50);

                entity.Property(e => e.PossibleConcession)
                    .HasColumnName("Possible_Concession")
                    .HasMaxLength(50);

                entity.Property(e => e.ProfessionalQuali)
                    .HasColumnName("Professional_Quali")
                    .HasMaxLength(50);

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TechnicalIssues)
                    .HasColumnName("Technical_Issues")
                    .HasMaxLength(50);

                entity.Property(e => e.WorkTel)
                    .HasColumnName("Work_Tel")
                    .HasMaxLength(50);

                entity.Property(e => e._2YrsExpInTheLast5Yrs20152020)
                    .HasColumnName("_2_YRS_EXP_IN_THE_LAST_5_YRS_2015_2020")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NewCandidates>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("New Candidates");

                entity.Property(e => e.Candidate)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CentreName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CircName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Circuit)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DistrName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Emis)
                    .IsRequired()
                    .HasColumnName("EMIS")
                    .HasMaxLength(150);

                entity.Property(e => e.ExamPeriod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ExamType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ExamTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Idno)
                    .IsRequired()
                    .HasColumnName("IDNo")
                    .HasMaxLength(150);

                entity.Property(e => e.MsNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Paper)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PaperDesc)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PaperDuration).HasMaxLength(50);

                entity.Property(e => e.PaperMax)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PaperTime)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PaperType)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ProvName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.RegName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Packets>(entity =>
            {
                entity.HasKey(e => e.CenterId);

                entity.Property(e => e.CenterId).HasColumnName("centerID");

                entity.Property(e => e.AssessmentIdentifier).HasMaxLength(150);

                entity.Property(e => e.CentreIdentifier).HasMaxLength(150);

                entity.Property(e => e.ComponentIdentifier).HasMaxLength(150);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasColumnType("datetime");

                entity.Property(e => e.SessionIdentifier).HasMaxLength(150);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.QualificationShortName)
                    .HasName("PK__Product__AA8197A50FA67EEF");

                entity.Property(e => e.QualificationShortName).HasMaxLength(50);

                entity.Property(e => e.AssessmentIndentifier)
                    .IsRequired()
                    .HasMaxLength(90);

                entity.Property(e => e.AssessmentName).HasMaxLength(50);

                entity.Property(e => e.ComponentIdentifier).HasMaxLength(50);

                entity.Property(e => e.ComponentName).HasMaxLength(50);
            });

            modelBuilder.Entity<QuestionPaper>(entity =>
            {
                entity.HasKey(e => e.QuestionPaperIdentifier);

                entity.Property(e => e.QuestionPaperIdentifier).HasMaxLength(50);

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MarkingType).HasMaxLength(50);

                entity.Property(e => e.QuestionPaperPartName).HasMaxLength(50);

                entity.Property(e => e.SyllabusCode).HasMaxLength(50);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.SessionIdentifier);

                entity.Property(e => e.SessionIdentifier).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Timeframe).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
