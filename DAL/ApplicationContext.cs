using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;

namespace DAL
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Section> Section { get; set; }
        public DbSet<SportsmanNote> SportsmanNote { get; set; }
        public DbSet<Analysis> Analysis { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<ObservationNote> ObservationNote { get; set; }
        public DbSet<UsersUsers> UsersUsers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //treatment
            modelBuilder.Entity<Treatment>()
                .HasOne(s => s.SportsmanUserId)
                .WithMany(a => a.TreatmentSportsman);
            modelBuilder.Entity<Treatment>()
                .HasOne(s => s.DoctorUserId)
                .WithMany(a => a.TreatmentDoctor);

            modelBuilder.Entity<User>()
                .HasMany(s => s.TreatmentSportsman)
                .WithOne(a => a.SportsmanUserId);
            modelBuilder.Entity<User>()
                .HasMany(s => s.TreatmentDoctor)
                .WithOne(a => a.DoctorUserId);

            //observationNote
            modelBuilder.Entity<ObservationNote>()
                .HasOne(s => s.DoctorUserId)
                .WithMany(f => f.ObservationNotes);

            modelBuilder.Entity<User>()
                .HasMany(s => s.ObservationNotes)
                .WithOne(a => a.DoctorUserId);

            modelBuilder.Entity<ObservationNote>()
                .HasOne(s => s.Treatment)
                .WithMany(a => a.ObservationNotes);

            modelBuilder.Entity<Treatment>()
                .HasMany(s => s.ObservationNotes)
                .WithOne(a => a.Treatment);

            //section
            modelBuilder.Entity<User>()
                .HasOne(s => s.BelongSection)
                .WithMany(a => a.UsersList);

            modelBuilder.Entity<Section>()
                .HasMany(s => s.UsersList)
                .WithOne(a => a.BelongSection);

            //sportNote
            modelBuilder.Entity<SportsmanNote>()
                .HasOne(s => s.SportsmanUserId)
                .WithMany(a => a.SportsmanNotes);

            modelBuilder.Entity<User>()
                .HasMany(s => s.SportsmanNotes)
                .WithOne(a => a.SportsmanUserId);

            //analysis
            modelBuilder.Entity<Analysis>()
                .HasOne(s => s.DoctorUserId)
                .WithMany(a => a.DoctorAnalyses);
            modelBuilder.Entity<Analysis>()
                .HasOne(s => s.SportsmanUserId)
                .WithMany(a => a.SportsmanAnalyses);

            modelBuilder.Entity<User>()
                .HasMany(s => s.DoctorAnalyses)
                .WithOne(a => a.DoctorUserId);
            modelBuilder.Entity<User>()
                .HasMany(s => s.SportsmanAnalyses)
                .WithOne(a => a.SportsmanUserId);

            //message
            modelBuilder.Entity<Message>()
                .HasOne(s => s.SenderId)
                .WithMany(a => a.MessageSender);
            modelBuilder.Entity<Message>()
                .HasOne(s => s.RecepientId)
                .WithMany(a => a.MessageRecepient);

            modelBuilder.Entity<User>()
                .HasMany(s => s.MessageSender)
                .WithOne(a => a.SenderId);
            modelBuilder.Entity<User>()
                .HasMany(s => s.MessageRecepient)
                .WithOne(a => a.RecepientId);

            //usersusers
            modelBuilder.Entity<UsersUsers>()
                .HasOne(s => s.ParentId)
                .WithMany(a => a.UserParentId);
            modelBuilder.Entity<UsersUsers>()
                .HasOne(s => s.ChildId)
                .WithMany(a => a.UserChildId);

            modelBuilder.Entity<User>()
                .HasMany(s => s.UserParentId)
                .WithOne(a => a.ParentId);
            modelBuilder.Entity<User>()
                .HasMany(s => s.UserChildId)
                .WithOne(a => a.ChildId);

        }
    }
}
