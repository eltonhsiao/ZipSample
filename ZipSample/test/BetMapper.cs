public class BetMapper : IMapper
{
    public BetDto Mapping(Bet bet)
    {
        return new BetDto()
        {
            BetId = bet.Id,
            Amount = (int)bet.Stake,
            Date = bet.CreatedDate.ToString("yyyyMMdd"),
            Status = bet.Status
        };
    }
}