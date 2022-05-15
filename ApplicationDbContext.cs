﻿using Back_end.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Back_end
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Genero> Generos { get; set; }
    }
}