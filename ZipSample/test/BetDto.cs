using System;

public class BetDto
{
    public int BetId { get; set; }
    public string Date { get; set; }
    public int Amount { get; set; }
    public string Status { get; set; }

    public BetDto BetDtoMapping(Bet bet, Func<Bet, BetDto> mapper)
    {
        return mapper(bet);
    }

    public BetDto BetDtoMap(Bet bet, IMapper mapper)
    {
        return mapper.Mapping(bet);
    }

    public BetDto BetDtoMap(Bet bet)    //use reflection
    {
        return new BetDto()
        {
            Status = bet.Status
        };
    }
}