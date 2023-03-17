namespace ConsoleApp1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ConsoleApp1.DAL;
    using System.Collections.Generic;

    public partial class SchoolDB : DbContext, IDBContext
    {
        public SchoolDB()
            : base("name=SchoolDB")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        IEnumerable<Student> IDBContext.AllStudents { get => this.Students; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.ClassId)
                .WillCascadeOnDelete(false);
        }
    }
}
