﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using Mc2.CrudTest.Shared;
using Mc2.CrudTest.Shared.Generators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<WeatherForecast> Get()
        {
            List<WeatherForecast> response =
                WeatherForecastGenerator.GenerateWeatherForecast();
            IPAddress userIp = HttpContext.Request.HttpContext.Connection
                .RemoteIpAddress;
            _logger.LogDebug(
                $"[Request from {userIp}: Serving Get() response: {string.Join("\n", response.ToList())}");
            return response;
        }
    }
}