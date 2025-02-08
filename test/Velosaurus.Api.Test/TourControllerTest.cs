using Velosaurus.Api.Controllers;

namespace Velosaurus.Api.Test;

public class ActivityControllerTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Hello_AllWorking_ReturnsHelloString()
    {
        var testController = new TestController();

        var result = testController.Hello();
        Assert.That(result, Is.EqualTo("Hello There =)... \nAPI can be reached at:\n/api/location \n/api/activity \n/swagger/index.html"));
    }
}