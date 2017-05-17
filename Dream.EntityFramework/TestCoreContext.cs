using Dream.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.EntityFramework
{
    public class TestCoreContext : DbContext
    {
        public TestCoreContext(DbContextOptions<TestCoreContext> options) : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<WorkFlowRequestForm> WorkFlowRequestForm { get; set; }

        public DbSet<KeyValue> KeyValue { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Manager> Manager { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkFlowRequestForm>()
                .HasOne(m => m.KeyValue1)
                .WithMany(n => n.WorkFlowRequestForm1)
                .HasForeignKey(n => n.Priority)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkFlowRequestForm>()
                .HasOne(m => m.KeyValue2)
                .WithMany(n => n.WorkFlowRequestForm2)
                .HasForeignKey(m => m.Status)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(m => m.PrimaryManager)
                .WithMany(n => n.PrimaryDepartments)
                .HasForeignKey(m => m.PrimaryManagerId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Department>()
                .HasOne(m => m.SecondManager)
                .WithMany(n => n.SecondDepartments)
                .HasForeignKey(m => m.SecondManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
