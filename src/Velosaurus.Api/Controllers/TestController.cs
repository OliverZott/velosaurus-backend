using Microsoft.AspNetCore.Mvc;

namespace Velosaurus.Api.Controllers;
[Route("/")]
[ApiController]
public class TestController : ControllerBase
{
    public TestController()
    {
    }

    [HttpGet]
    public string Hello() => $"Hello There John =)";
}
