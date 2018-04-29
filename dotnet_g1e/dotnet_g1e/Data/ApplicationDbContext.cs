using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using dotnet_g1e.Models;
using dotnet_g1e.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_g1e.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Breakoutbox> Breakoutboxes { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Modifier> Modifiers { get; set; }
        public DbSet<Models.Domain.Action> Actions { get; set; }
        public DbSet<PlayGroup> PlayGroups { get; set; }
        public DbSet<Classgroup> Classgroups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<AccessCode>(MapAccessCode);
            builder.Entity<BreakoutboxAction>(MapBreakoutboxAction);
            builder.Entity<BreakoutboxExercise>(MapBreakoutboxExercise);
            builder.Entity<BreakoutboxAccessCode>(MapBreakoutboxAccessCode);
            builder.Entity<ExerciseModifier>(MapExerciseModifier);
            builder.Entity<SessionPlayGroup>(MapSessionPlayGroup);
            builder.Entity<PlayGroupPupil>(MapPlayGroupPupil);
            builder.Entity<ClassGroupPupil>(MapClassGroupPupil);
            builder.Entity<Modifier>(MapModifier);
            builder.Entity<Result<string>>(MapResult);
        }

        private static void MapAccessCode(EntityTypeBuilder<AccessCode> a)
        {
            a.HasKey(t => t.AccessCodeId);
        }

        private static void MapAction(EntityTypeBuilder<Models.Domain.Action> a)
        {
            a.HasKey(t => t.ActionId);
        }

        private static void MapExercise(EntityTypeBuilder<Exercise> b)
        {
            b.HasKey(t => t.ExerciseId);
            b.HasOne(t => t.Result);
        }

        private static void MapBreakoutbox(EntityTypeBuilder<Breakoutbox> b)
        {
            b.HasKey(t => t.BreakoutboxId);
        }

        private static void MapModifier(EntityTypeBuilder<Modifier> b)
        {
            b.HasKey(t => t.ModifierId);
            b.HasDiscriminator<string>("Type")
                .HasValue<AddModifier>("AddModifier");
        }

        private static void MapBreakoutboxAction(EntityTypeBuilder<BreakoutboxAction> b)
        {
            b.HasKey(t => new { t.BreakoutboxId, t.ActionId });
            b.HasOne(t => t.Breakoutbox)
                .WithMany(t => t.BreakoutboxActions)
                .HasForeignKey(t => t.BreakoutboxId);
            b.HasOne(t => t.Action)
                .WithMany(t => t.BreakoutboxActions)
                .HasForeignKey(t => t.ActionId);
        }

        private static void MapBreakoutboxAccessCode(EntityTypeBuilder<BreakoutboxAccessCode> b)
        {
            b.HasKey(t => new { t.AccessCodeId, t.BreakoutboxId });
            b.HasOne(t => t.Breakoutbox)
                .WithMany(t => t.BreakoutboxAccessCodes)
                .HasForeignKey(t => t.BreakoutboxId);
            b.HasOne(t => t.AccessCode)
                .WithMany(t => t.BreakoutboxAccessCodes)
                .HasForeignKey(t => t.AccessCodeId);
        }

        private static void MapBreakoutboxExercise(EntityTypeBuilder<BreakoutboxExercise> b)
        {
            b.HasKey(t => new { t.BreakoutboxId, t.ExerciseId });
            b.HasOne(t => t.Breakoutbox)
                .WithMany(t => t.BreakoutboxExercises)
                .HasForeignKey(t => t.BreakoutboxId);
            b.HasOne(t => t.Exercise)
                .WithMany(t => t.BreakoutboxExercises)
                .HasForeignKey(t => t.ExerciseId);
        }

        private static void MapExerciseModifier(EntityTypeBuilder<ExerciseModifier> b)
        {
            b.HasKey(t => new { t.ExerciseId, t.ModifierId });
            b.HasOne(t => t.Exercise)
                .WithMany(t => t.ExerciseModifiers)
                .HasForeignKey(t => t.ExerciseId);
            b.HasOne(t => t.Modifier)
                .WithMany(t => t.ExerciseModifiers)
                .HasForeignKey(t => t.ModifierId);
        }


        private static void MapResult(EntityTypeBuilder<Result<string>> b)
        {
            b.HasKey(t => t.ResultId);
        }

        private static void MapSession(EntityTypeBuilder<Session> b)
        {
            b.HasKey(t => t.SessionId);
            b.HasOne(t => t.Breakoutbox);
            b.HasOne(t => t.Classgroup);
        }

        private static void MapSessionPlayGroup(EntityTypeBuilder<SessionPlayGroup> b)
        {
            b.HasKey(t => new { t.PlayGroupId, t.SessionId });
            b.HasOne(t => t.Session)
                .WithMany(t => t.SessionPlayGroups)
                .HasForeignKey(t => t.SessionId);
            b.HasOne(t => t.PlayGroup)
                .WithMany(t => t.SessionPlayGroups)
                .HasForeignKey(t => t.PlayGroupId);
        }

        private static void MapPlayGroupPupil(EntityTypeBuilder<PlayGroupPupil> b)
        {
            b.HasKey(t => new { t.PlayGroupId, t.PupilId });
            b.HasOne(t => t.Pupil)
                .WithMany(t => t.PlayGroupPupils)
                .HasForeignKey(t => t.PupilId);
            b.HasOne(t => t.PlayGroup)
                .WithMany(t => t.PlayGroupPupils)
                .HasForeignKey(t => t.PlayGroupId);
        }

        private static void MapClassGroupPupil(EntityTypeBuilder<ClassGroupPupil> b)
        {
            b.HasKey(t => new { t.ClassGroupId, t.PupilId });
            b.HasOne(t => t.Pupil)
                .WithMany(t => t.ClassGroupPupils)
                .HasForeignKey(t => t.PupilId);
            b.HasOne(t => t.Classgroup)
                .WithMany(t => t.ClassGroupPupils)
                .HasForeignKey(t => t.ClassGroupId);
        }
    }
}
