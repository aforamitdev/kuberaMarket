namespace KM.Repositories.Exchange;

public class ExchangeRepository
{
    private readonly IGraphDbContext _db;

    public ExchangeRepository(IGraphDbContext db)
    {
        _db = db;
    }



}