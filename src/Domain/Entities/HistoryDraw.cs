namespace LotteryDraw.Domain.Entities;

public class HistoryDraw
{
    public int Id { get; set; }
    public DateTime DrawTime { get; set; }
    public byte FirstNumber { get; set; }
    public byte SecondNumber { get; set; }
    public byte ThirdNumber { get; set; }
    public byte FourthNumber { get; set; }
    public byte FifthNumber { get; set; }
}
