namespace DashCache.Domain.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entities;
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
            : base("name=SchoolDbContext")
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentsCourses> StudentsCourses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.StudentsCourses)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentsCourses)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
