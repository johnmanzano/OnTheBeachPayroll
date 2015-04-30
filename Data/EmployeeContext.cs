using System.Data.Entity;

namespace Data
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .Property(c => c.ConversionFactor).HasColumnName("conversionFactor");
            modelBuilder.Entity<Currency>()
                .Property(e => e.Unit).IsUnicode(false).HasColumnName("unit");
            modelBuilder.Entity<Currency>()
                .Property(c => c.Id).HasColumnName("id");

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.Salaries)
                .WithRequired(e => e.Currency)
                .HasForeignKey(e => e.CurrencyId)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<Employee>()
                .Property(c => c.Id).HasColumnName("id");
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name).HasColumnName("name").IsUnicode(false);
            modelBuilder.Entity<Employee>()
                .Property(c => c.RoleId).HasColumnName("role_id");

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Salaries)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<Role>()
                .Property(e => e.Name).HasColumnName("name").IsUnicode(false);
            modelBuilder.Entity<Role>()
                .Property(c => c.Id).HasColumnName("id");

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Salary>()
                .Property(c => c.Id).HasColumnName("id");
            modelBuilder.Entity<Salary>()
                .Property(c => c.EmployeeId).HasColumnName("employee_id");
            modelBuilder.Entity<Salary>()
                .Property(c => c.CurrencyId).HasColumnName("currency_id");
            modelBuilder.Entity<Salary>()
                .Property(c => c.AnnualAmount).HasColumnName("annual_amount");

        }
    }
}
