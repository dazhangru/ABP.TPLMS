﻿using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ABP.TPLMS.Authorization.Roles;
using ABP.TPLMS.Authorization.Users;
using ABP.TPLMS.MultiTenancy;
using ABP.TPLMS.Entities;

namespace ABP.TPLMS.EntityFrameworkCore
{
    public class TPLMSDbContext : AbpZeroDbContext<Tenant, Role, User, TPLMSDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public TPLMSDbContext(DbContextOptions<TPLMSDbContext> options)
            : base(options)
        {
        }
        public DbSet<Module> Modules { get; set; }
    }
}
