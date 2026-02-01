using KM.Application.Dtos;
using KM.Models.Exchange;

namespace KM.Application.Services;

public interface IExchangeService
{
    Task Create(CreateExchangeDto exchange);
    Task<IEnumerable<Exchange>> GetExchange();

}