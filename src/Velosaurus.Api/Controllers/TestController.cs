using Microsoft.AspNetCore.Mvc;

namespace Velosaurus.Api.Controllers;

[Route("/")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Hello()
    {
        return "Hello There =)... \n" +
               "API can be reached at:\n" +
               "/api/location \n" +
               "/api/activity \n" +
               "/swagger/index.html";
    }
}