using LotteryDraw.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LotteryDraw.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<HistoryDraw> DrawHistory { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
