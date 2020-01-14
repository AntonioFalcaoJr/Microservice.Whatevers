using Microsoft.EntityFrameworkCore;
using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Data.Context
{
    public class WhateverContext : DbContext
    {
        public DbSet<Whatever> MyProperty { get; set; }
    }
}