using System;
using Microsoft.AspNetCore.Mvc;

namespace ResolucaoDepencia.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly Func<ServiceEnum, ICustomLogger> _serviceSolver;
    
    public HomeController(Func<ServiceEnum, ICustomLogger> serviceSolver)
    {
        _serviceSolver = serviceSolver;
    }

    [HttpGet("Database")]
    public ActionResult<string> Database()
    {
        var databaseLogger = _serviceSolver(ServiceEnum.Database);
        return databaseLogger.Write($"Requisição efetuada em: { DateTime.Now }.");
    }
    
    [HttpGet("Event")]
    public ActionResult<string> Event()
    {
        var eventLogger = _serviceSolver(ServiceEnum.Event);
        return eventLogger.Write($"Requisição efetuada em: { DateTime.Now }.");
    }

    [HttpGet("File")]
    public ActionResult<string> File()
    {
        var fileLogger = _serviceSolver(ServiceEnum.File);
        return fileLogger.Write($"Requisição efetuada em: { DateTime.Now }.");
    }
}
