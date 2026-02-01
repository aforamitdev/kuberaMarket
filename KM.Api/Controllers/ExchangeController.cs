using KM.Application.Dtos;
using KM.Application.Services;
using KM.Models.Exchange;
using Lucene.Net.Util.Fst;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KuberaMarket.Controllers;


[ApiController]
[Route("api/exchange")]
public class ExchangeController:ControllerBase
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

    [HttpGet]
    public async Task<IActionResult> GetExchanges()
    {
        var exchanges = await _services.GetExchange();
        return Ok(exchanges);
    }
}