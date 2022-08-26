using System.Reflection;
using LotteryDraw.Application.Common.Interfaces;
using LotteryDraw.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LotteryDraw.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<HistoryDraw> DrawHistory => Set<HistoryDraw>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
