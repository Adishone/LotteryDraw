using LotteryDraw.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LotteryDraw.Infrastructure.Persistence.Configurations;

public class HistoryDrawConfiguration : IEntityTypeConfiguration<HistoryDraw>
{
    public void Configure(EntityTypeBuilder<HistoryDraw> builder)
    {
        builder.Property(hd => hd.Id).UseIdentityColumn();
        builder.Property(hd => hd.DrawTime).IsRequired();
        builder.Property(hd => hd.FirstNumber).IsRequired();
        builder.Property(hd => hd.SecondNumber).IsRequired();
        builder.Property(hd => hd.ThirdNumber).IsRequired();
        builder.Property(hd => hd.FourthNumber).IsRequired();
        builder.Property(hd => hd.FifthNumber).IsRequired();
    }
}
