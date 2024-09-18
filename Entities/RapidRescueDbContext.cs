using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rapid_Rescue.Entities;

public partial class RapidRescueDbContext : DbContext
{
    public static string ConnectionString;
    public RapidRescueDbContext()
    {
    }

    public RapidRescueDbContext(DbContextOptions<RapidRescueDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ambulance> Ambulances { get; set; }

    public virtual DbSet<AmbulanceType> AmbulanceTypes { get; set; }

    public virtual DbSet<ContactUsQuery> ContactUsQueries { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<EmergencyRequest> EmergencyRequests { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FirstAidInstruction> FirstAidInstructions { get; set; }

    public virtual DbSet<ImageGallery> ImageGalleries { get; set; }

    public virtual DbSet<MedicalProfile> MedicalProfiles { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ambulance>(entity =>
        {
            entity.HasKey(e => e.AmbulanceId).HasName("PK__Ambulanc__F6624EFCAE332F11");

            entity.Property(e => e.AmbulanceId).HasColumnName("ambulance_id");
            entity.Property(e => e.AmbulanceTypeId).HasColumnName("ambulance_type_id");
            entity.Property(e => e.CurrentLatitude)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("current_latitude");
            entity.Property(e => e.CurrentLongitude)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("current_longitude");
            entity.Property(e => e.EquipmentDetails)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("equipment_details");
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("registration_number");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.AmbulanceType).WithMany(p => p.Ambulances)
                .HasForeignKey(d => d.AmbulanceTypeId)
                .HasConstraintName("FK_Ambulances_Ambulance_Types");
        });

        modelBuilder.Entity<AmbulanceType>(entity =>
        {
            entity.HasKey(e => e.AmbulanceTypeId).HasName("PK__Ambulanc__94CEC8E985BB7A39");

            entity.ToTable("Ambulance_Types");

            entity.Property(e => e.AmbulanceTypeId).HasColumnName("ambulance_type_id");
            entity.Property(e => e.Equipment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("equipment");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.Size)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("size");
            entity.Property(e => e.TypeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<ContactUsQuery>(entity =>
        {
            entity.HasKey(e => e.QueryId).HasName("PK__Contact___E793E349781BD836");

            entity.ToTable("Contact_Us_Queries");

            entity.Property(e => e.QueryId).HasColumnName("query_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contact_number");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.SubmittedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("submitted_at");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__Drivers__A411C5BD28BBD9FD");

            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.AmbulanceId).HasColumnName("ambulance_id");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contact_info");
            entity.Property(e => e.CurrentLatitude)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("current_latitude");
            entity.Property(e => e.CurrentLongitude)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("current_longitude");
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("license_number");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Ambulance).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.AmbulanceId)
                .HasConstraintName("FK_Drivers_Ambulances");

            entity.HasOne(d => d.User).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Drivers_Users");
        });

        modelBuilder.Entity<EmergencyRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Emergenc__18D3B90FE741A534");

            entity.ToTable("Emergency_Requests");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.AmbulanceId).HasColumnName("ambulance_id");
            entity.Property(e => e.CustomerMobileNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_mobile_number");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.EmergencyType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("emergency_type");
            entity.Property(e => e.HospitalAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("hospital_address");
            entity.Property(e => e.HospitalName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("hospital_name");
            entity.Property(e => e.PickupAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pickup_address");
            entity.Property(e => e.RequestedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("requested_at");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Ambulance).WithMany(p => p.EmergencyRequests)
                .HasForeignKey(d => d.AmbulanceId)
                .HasConstraintName("FK_Emergency_Requests_Ambulances");

            entity.HasOne(d => d.Driver).WithMany(p => p.EmergencyRequests)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK_Emergency_Requests_Drivers");

            entity.HasOne(d => d.User).WithMany(p => p.EmergencyRequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Emergency_Requests_Users");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__7A6B2B8CD9A273F1");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Feedback_Users");
        });

        modelBuilder.Entity<FirstAidInstruction>(entity =>
        {
            entity.HasKey(e => e.InstructionId).HasName("PK__First_Ai__4FC97B74363F0E1E");

            entity.ToTable("First_Aid_Instructions");

            entity.Property(e => e.InstructionId).HasColumnName("instruction_id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<ImageGallery>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Image_Ga__DC9AC95547A09B49");

            entity.ToTable("Image_Gallery");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.AmbulanceTypeId).HasColumnName("ambulance_type_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");

            entity.HasOne(d => d.AmbulanceType).WithMany(p => p.ImageGalleries)
                .HasForeignKey(d => d.AmbulanceTypeId)
                .HasConstraintName("FK_Image_Gallery_Ambulance_Types");
        });

        modelBuilder.Entity<MedicalProfile>(entity =>
        {
            entity.HasKey(e => e.MedicalProfileId).HasName("PK__Medical___32C2629A32123CB0");

            entity.ToTable("Medical_Profiles");

            entity.Property(e => e.MedicalProfileId).HasColumnName("medical_profile_id");
            entity.Property(e => e.Allergies)
                .HasColumnType("text")
                .HasColumnName("allergies");
            entity.Property(e => e.BloodType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("blood_type");
            entity.Property(e => e.MedicalHistory)
                .HasColumnType("text")
                .HasColumnName("medical_history");
            entity.Property(e => e.Medications)
                .HasColumnType("text")
                .HasColumnName("medications");
            entity.Property(e => e.OtherNotes)
                .HasColumnType("text")
                .HasColumnName("other_notes");
            entity.Property(e => e.UpdatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.MedicalProfiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Medical_Profiles_Users");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Messages__0BBF6EE6706C6696");

            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.MessageContent)
                .HasColumnType("text")
                .HasColumnName("message_content");
            entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.SentAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("sent_at");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK_Messages_Users_Receiver");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK_Messages_Users_Sender");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__E059842FB79F9BB0");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("is_read");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.NotificationType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("notification_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Notifications_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370FBA616FD8");

            entity.ToTable(tb => tb.HasTrigger("trg_UpdateTimestamp"));

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164E2DF3024").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmergencyContactName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("emergency_contact_name");
            entity.Property(e => e.EmergencyContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("emergency_contact_phone");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
