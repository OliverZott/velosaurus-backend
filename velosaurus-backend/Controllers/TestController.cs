using Microsoft.AspNetCore.Mvc;

namespace velosaurus_backend.Controllers;
[Route("/")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Get() => "Hello There =)";
}
