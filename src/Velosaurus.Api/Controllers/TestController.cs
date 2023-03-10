using Microsoft.AspNetCore.Mvc;

namespace Velosaurus.Api.Controllers;
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
    public string Get() => $"Hello There =)";
}
