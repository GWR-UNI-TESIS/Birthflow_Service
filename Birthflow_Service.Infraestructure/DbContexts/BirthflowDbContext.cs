using Birthflow_Domain.Entities;
using Birthflow_Service.Domain.Models;
using BirthflowMicroServices.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Service.Infraestructure.DbContexts
{
    public class BirthflowDbContext : IdentityDbContext<ApplicationUser>
    {
        public BirthflowDbContext(DbContextOptions<BirthflowDbContext> options) : base(options)
        {

        }

        // AUTH
        public virtual DbSet<UsuarioEntity> Usuarios { get; set; }
        public virtual DbSet<PasswordEntity> Passwords { get; set; }
        public virtual DbSet<PartographEntity> Partographs { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Ignore<IdentityRole>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
        }
    }
}
