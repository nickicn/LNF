using LNF.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LNF.API.Data;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }        
    public DbSet<Category> Categories { get; set; }        
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedDefaultUser(builder);
    }

    private static void SeedDefaultUser(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Usuário",
               NormalizedName = "USUÁRIO"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<User> usuarios = new() {
            new User(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "letcajatobas@gmail.com",
                NormalizedEmail = "LETCAJATOBA@GMAIL.COM",
                UserName = "Jatossiane",
                NormalizedUserName = "JATOSSIANE",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Name = "Leticia Cassiane Jatobá"
            }
        };
        foreach (var user in usuarios)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<User>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

}
