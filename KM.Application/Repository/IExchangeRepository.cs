using KM.Application.Dtos;
using KM.Models.Exchange;

namespace KM.Application.Repository;

public interface IExchangeRepository
{
    Task Create(Exchange exchange);
    
    Task<IEnumerable<Exchange>> GetAll();

}