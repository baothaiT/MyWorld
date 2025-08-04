using System;
using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities;
using Template.Infra;

namespace Template.API.Configs;

public class DbMigrationJob : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<DbMigrationJob> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DbMigrationJob"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider used to create and manage services.</param>
    /// <param name="logger">The logger used to log information and errors.</param>
    public DbMigrationJob(IServiceProvider serviceProvider, ILogger<DbMigrationJob> logger)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Starts the database migration process.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token used to propagate notification that the operation should be canceled.</param>
    /// <returns>A task that represents the asynchronous start operation.</returns>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // Create a scope to manage the lifecycle of the services.
        using var scope = _serviceProvider.CreateScope();

        // Get the application database context from the service provider.
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            // Log connection string for debugging (remove in production)
            var connectionString = context.Database.GetConnectionString();
            _logger.LogInformation("Using connection string: {ConnectionString}", 
                string.IsNullOrEmpty(connectionString) ? "NULL OR EMPTY" : "***CONFIGURED***");

            // Apply any pending migrations to the database.
            _logger.LogInformation("Starting database migration...");
            
            // Check if there are any pending migrations
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync(cancellationToken);
            
            if (pendingMigrations.Any())
            {
                _logger.LogInformation("Found {Count} pending migrations. Applying migrations...", pendingMigrations.Count());
                
                // Apply pending migrations
                await context.Database.MigrateAsync(cancellationToken);
                
                _logger.LogInformation("Database migration completed successfully.");
            }
            else
            {
                _logger.LogInformation("No pending migrations found. Database is up to date.");
            }

            // Seed data if no vocabularies exist
            await SeedVocabularyData(context, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while migrating the database.");
            throw; // Re-throw to prevent application startup if migration fails
        }
    }

    /// <summary>
    /// Stops the database migration process.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token used to propagate notification that the operation should be canceled.</param>
    /// <returns>A task that represents the asynchronous stop operation.</returns>
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    private async Task SeedVocabularyData(AppDbContext context, CancellationToken cancellationToken)
    {
        if (!await context.Vocabularies.AnyAsync(cancellationToken))
        {
            var seedData = new List<VocabularyEntity>
            {
                new() { Id = Guid.NewGuid(), Key = "Welcome", Value = "Hello and welcome to our application!" },
                new() { Id = Guid.NewGuid(), Key = "Goodbye", Value = "Thank you for using our application!" },
                new() { Id = Guid.NewGuid(), Key = "Error", Value = "An error occurred. Please try again." },
                new() { Id = Guid.NewGuid(), Key = "Success", Value = "Operation completed successfully!" }
            };

            await context.Vocabularies.AddRangeAsync(seedData, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            
            _logger.LogInformation("Vocabulary seed data added successfully.");
        }
        else
        {
            _logger.LogInformation("Vocabulary data already exists. Skipping seed data insertion.");
        }
    }
}