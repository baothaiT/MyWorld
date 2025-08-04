using System;
using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities;

namespace Template.Infra;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<VocabularyEntity> Vocabularies { get; set; }
}
