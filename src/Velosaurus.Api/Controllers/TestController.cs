using Microsoft.AspNetCore.Mvc;

namespace Velosaurus.Api.Controllers;

[Route("/")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public ContentResult Hello()
    {
        var html = @"
        <html>
            <body style='font-family: sans-serif;'>
                <p>Hello There :)</p>
                <p>API can be reached at:</p>
                <ul>
                    <li><a href='http://localhost:8000/api/v1/location' target='_blank'>Location API</a></li>
                    <li><a href='http://localhost:8000/api/v1/activity' target='_blank'>Activity API</a></li>
                    <li><a href='http://localhost:8000/swagger/index.html' target='_blank'>Swagger UI</a></li>
                </ul>
            </body>
        </html>";

        return Content(html, "text/html");
    }
}