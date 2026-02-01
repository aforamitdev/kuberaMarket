using KM.Application.Dtos;
using KM.Application.Services;
using KM.Models.Exchange;
using Microsoft.AspNetCore.Mvc;

namespace KuberaMarket.Controllers;


[ApiController]
[Route("api/exchange")]
public class ExchangeController
{

    private readonly IExchangeService _services;

    public ExchangeController(IExchangeService service)
    {
        _services=service;
    }

    [HttpPost]
    public async Task CreateExchange(CreateExchangeDto request)
    {
        await _services.Create(request);
    }
}