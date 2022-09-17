//using System;
//using Cinema.Dal.Dbo;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;

//namespace Cinema.Dal.Data
//{
//    public class CinemaDbContext : IdentityDbContext<UsersDbo,
//        RoleDbo,
//        Guid,
//        IdentityUserClaim<Guid>,
//        UsersRoleDbo,
//        IdentityUserLogin<Guid>,
//        IdentityRoleClaim<Guid>,
//        IdentityUserToken<Guid>>
//    {

//        public DbSet<UsersDbo> User { get; set; }    
//        public DbSet<RoleDbo> Roles { get; set; }


//        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
//            : base(options)
//        {
//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            var configuration = new ConfigurationBuilder()
//            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//            .AddJsonFile("appsettings.json")
//            .AddEnvironmentVariables()
//            .Build();
//            var connectionString = configuration.GetConnectionString("CinemaContext");
//            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28)));
//            base.OnConfiguring(optionsBuilder);
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);



//            modelBuilder.Entity<UsersRoleDbo>(eRole =>
//            {
//                eRole.HasKey(e => new { e.UserId, e.RoleId });

//                eRole
//                    .HasOne(r => r.Role)
//                    .WithMany(r => r.UsersRoles)
//                    .HasForeignKey(r => r.RoleId)
//                    .IsRequired();

//                eRole
//                    .HasOne(r => r.Users)
//                    .WithMany(r => r.UsersRoles)
//                    .HasForeignKey(r => r.UserId)
//                    .IsRequired();
//            });

//        }
//    }
//}







using System;
using Cinema.Dal.Dbo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cinema.Dal.Data
{
    public class CinemaDbContext : IdentityDbContext<UsersDbo,
        RoleDbo,
        Guid,
        IdentityUserClaim<Guid>,
        UsersRoleDbo,
        IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>,
        IdentityUserToken<Guid>>

    {
        public DbSet<CinemaDbo> Cinemas { get; set; }
        public DbSet<HallDbo> Halls { get; set; }
        public DbSet<MovieDbo> Movies { get; set; }
        public DbSet<SessionMovieDbo> SessionMovies { get; set; }
        public DbSet<RoleDbo> Roles { get; set; }
        public DbSet<UsersDbo> Users { get; set; }



        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
            var connectionString = configuration.GetConnectionString("CinemaContext");
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28)));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsersRoleDbo>(eRole =>
            {
                eRole.HasKey(e => new { e.UserId, e.RoleId });

                eRole
                    .HasOne(r => r.Role)
                    .WithMany(r => r.UsersRoles)
                    .HasForeignKey(r => r.RoleId)
                    .IsRequired();

                eRole
                    .HasOne(r => r.Users)
                    .WithMany(r => r.UsersRoles)
                    .HasForeignKey(r => r.UserId)
                    .IsRequired();
            });


            modelBuilder.Entity<SessionMovieDbo>()
                .HasOne(t => t.Movie)
                .WithMany(p => p.SessionMovies)
                .HasForeignKey(t => t.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SessionMovieDbo>()
                .HasOne(t => t.Hall)
                .WithMany(p => p.SessionMovies)
                .HasForeignKey(t => t.HallId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HallDbo>()
                .HasOne(t => t.Cinema)
                .WithMany(p => p.Halls)
                .HasForeignKey(t => t.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<SessionMovieDbo>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<SessionMovieDbo>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<HallDbo>().HasQueryFilter(c => !c.IsDeleted);

        }

    }
}
