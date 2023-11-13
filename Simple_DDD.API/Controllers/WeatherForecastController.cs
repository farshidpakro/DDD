using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simple_DDD.API.Services;
using Simple_DDD.API.Services.Interfaces;
using Simple_DDD.API.UIRes;
using Simple_DDD.Domain.DTOs;

namespace Simple_DDD.API.Controllers;

[ApiController]
[Route("[controller]")]

public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IUserLoginServices _userlogin;
    private readonly ICurrentUserServices _currentUser;
     private readonly IMapper _mapper;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserLoginServices userlogin, ICurrentUserServices currentUser,IMapper mapper)
    {
        _logger = logger;
        _userlogin = userlogin;
        _currentUser = currentUser;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Authorize]
    public IEnumerable<WeatherForecast> Get()
    {
        var id = _currentUser.GetUserId();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpGet("GetToken")]
    public async Task<IActionResult> GetToken()
    {
        try
        {
            
             //var model = _mapper.Map<UserDto>(user);
            var res = await _userlogin.GetToken("1", "1", "email");
            return new BaseApiResult<string>().Success(res);
        }
        catch (Exception ex)
        {
            return new BaseApiResult<string>().ServerError(ex.Message);
        }
    }
     [HttpPost("InsertUser")]
    public async Task<IActionResult> InsertUser(UserDto input)
    {
        try
        {
            
          _userlogin.InsertUser(input);
            return new BaseApiResult<string>().Void();
        }
        catch (Exception ex)
        {
            return new BaseApiResult<string>().ServerError(ex.Message);
        }
    }
    [HttpGet("GetUserList")]
    public async Task<IActionResult> GetUserList()
    {
        try
        {
            
             //var model = _mapper.Map<UserDto>(user);
            var res =  _userlogin.GetUserList();
            return new BaseApiResult<List<UserDto>>().Success(res);
        }
        catch (Exception ex)
        {
            return new BaseApiResult<string>().ServerError(ex.Message);
        }
    }
}
