using KM.Application.Dtos;

namespace KM.Application.Services;

public interface IExchangeService
{
    Task Create(CreateExchangeDto exchange);

}