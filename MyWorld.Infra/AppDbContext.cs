using System;
using Microsoft.EntityFrameworkCore;
using MyWorld.Domain.Entities;

namespace MyWorld.Infra;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<VocabularyEntity> Vocabularies { get; set; }
}
