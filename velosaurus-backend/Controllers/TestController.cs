using Microsoft.AspNetCore.Mvc;

namespace velosaurus_backend.Controllers;
[Route("/")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public TestController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public string Get() => $"Hello There =) {_configuration["Zim:Name"]}\nDB: {_configuration["MongoDb:url"]}";
}
