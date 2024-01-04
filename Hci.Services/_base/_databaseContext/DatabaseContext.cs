using Hci.Models.Entities;
using Hci.Models.Security;
using Hci.Models.Sites;
using Hci.Models.Visits;
using Microsoft.EntityFrameworkCore;

namespace Hci.Services;

internal class DatabaseContext : DbContext
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="T:Microsoft.EntityFrameworkCore.DbContext" /> class using the
    ///     specified options.
    ///     The
    ///     <see
    ///         cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />
    ///     method will still be called to allow further
    ///     configuration of the options.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
    ///     and
    ///     <see href="https://aka.ms/efcore-docs-dbcontext-options">Using DbContextOptions</see> for more information and
    ///     examples.
    /// </remarks>
    /// <param name="options">The options for this context.</param>
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Hospital> Hospitals { get; set; }
    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<Visit> Visits { get; set; }

    /// <summary>
    ///     <para>
    ///         Override this method to configure the database (and other options) to be used for this context.
    ///         This method is called for each instance of the context that is created.
    ///         The base implementation does nothing.
    ///     </para>
    ///     <para>
    ///         In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may
    ///         not have been passed
    ///         to the constructor, you can use
    ///         <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
    ///         the options have already been set, and skip some or all of the logic in
    ///         <see
    ///             cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />
    ///         .
    ///     </para>
    /// </summary>
    /// <param name="optionsBuilder">
    ///     A builder used to create or modify options for this context. Databases (and other extensions)
    ///     typically define extension methods on this object that allow you to configure the context.
    /// </param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Enables to save the stack trace into the database (we will not use it)
        optionsBuilder.EnableSensitiveDataLogging();
    }

    /// <summary>
    ///     Override this method to further configure the model that was discovered by convention from the entity types
    ///     exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting
    ///     model may be cached
    ///     and re-used for subsequent instances of your derived context.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         If a model is explicitly set on the options for this context (via
    ///         <see
    ///             cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />
    ///         )
    ///         then this method will not be run. However, it will still run when creating a compiled model.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more
    ///         information and
    ///         examples.
    ///     </para>
    /// </remarks>
    /// <param name="modelBuilder">
    ///     The builder being used to construct the model for this context. Databases (and other extensions) typically
    ///     define extension methods on this object that allow you to configure aspects of the model that are specific
    ///     to a given database.
    /// </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.ToTable("Users");

            e.HasData(new User
            {
                UserId = 1,
                FirstName = "John",
                LastName = "Doe",
                CreatedById = 1, // this would be none differently, but let's keep it simple
                RecordDate = DateTime.Today
            });
        });

        modelBuilder.Entity<Hospital>(e =>
        {
            e.ToTable("Hospitals");
            e.HasOne(h => h.User).WithMany(w => w.Hospitals).HasForeignKey(k => k.CreatedById);
            e.HasMany(m => m.Visits).WithOne(w => w.Hospital).HasForeignKey(k => k.HospitalId);

            e.HasData(new List<Hospital>
            {
                new() { HospitalId = 1, Name = "Beacon Hospital", CreatedById = 1, RecordDate = DateTime.Today },
                new() { HospitalId = 2, Name = "Cavan General Hospital", CreatedById = 1, RecordDate = DateTime.Today }
            });
        });

        modelBuilder.Entity<Person>(e =>
        {
            e.ToTable("Persons");
            e.Ignore(i => i.FullName);
            e.HasOne(h => h.User).WithMany(w => w.Persons).HasForeignKey(k => k.CreatedById);
            e.HasMany(m => m.Visits).WithOne(w => w.Person).HasForeignKey(k => k.PersonId);

            e.HasData(new List<Person>
            {
                new() { PersonId = 1, FirstName = "John", LastName = "Smith", DocumentType = DocumentType.CitizenCard, DocumentId = "IR894256", CreatedById = 1, RecordDate = DateTime.Today },
                new() { PersonId = 2, FirstName = "Raegan", LastName = "Gardner", DocumentType = DocumentType.CitizenCard, DocumentId = "US97455881", CreatedById = 1, RecordDate = DateTime.Today },
                new() { PersonId = 3, FirstName = "Kaylah", LastName = "Wilkinson", DocumentType = DocumentType.Unknown, CreatedById = 1, RecordDate = DateTime.Today },
            });
        });

        modelBuilder.Entity<Visit>(e =>
        {
            e.ToTable("Visits");
            e.HasOne(h => h.User).WithMany(w => w.Visits).HasForeignKey(k => k.CreatedById);
            e.HasOne(h => h.Person).WithMany(w => w.Visits).HasForeignKey(k => k.PersonId);
            e.HasOne(h => h.Hospital).WithMany(w => w.Visits).HasForeignKey(k => k.HospitalId);

            e.HasData(new List<Visit>
            {
                new() { VisitId = 1, HospitalId = 1, PersonId = 1, EntryDate = DateTime.Today.AddDays(-3).AddHours(-4), ExitDate = DateTime.Today.AddDays(-3).AddHours(-3), CreatedById = 1, RecordDate = DateTime.Today },
                new() { VisitId = 2, HospitalId = 1, PersonId = 2, EntryDate = DateTime.Today.AddDays(-2).AddHours(-3), ExitDate = DateTime.Today.AddDays(-2).AddHours(-2).AddMinutes(-28), CreatedById = 1, RecordDate = DateTime.Today },
                new() { VisitId = 3, HospitalId = 1, PersonId = 1, EntryDate = DateTime.Today.AddDays(-2).AddHours(-2), ExitDate = DateTime.Today.AddDays(-2).AddHours(-1).AddMinutes(-37), CreatedById = 1, RecordDate = DateTime.Today },
                new() { VisitId = 4, HospitalId = 2, PersonId = 3, EntryDate = DateTime.Today.AddDays(-2).AddHours(-3), ExitDate = DateTime.Today.AddDays(-2).AddHours(-1), CreatedById = 1, RecordDate = DateTime.Today },
                new() { VisitId = 5, HospitalId = 1, PersonId = 2, EntryDate = DateTime.Today.AddHours(-4), ExitDate = DateTime.Today.AddHours(-3).AddMinutes(-25), CreatedById = 1, RecordDate = DateTime.Today },
                new() { VisitId = 8, HospitalId = 2, PersonId = 3, EntryDate = DateTime.Today.AddHours(-3), ExitDate = DateTime.Today.AddHours(-2).AddMinutes(-40), CreatedById = 1, RecordDate = DateTime.Today },
            });
        });


        // prevent cascade delete
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => fk is { IsOwnership: false, DeleteBehavior: DeleteBehavior.Cascade });

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;
    }
}