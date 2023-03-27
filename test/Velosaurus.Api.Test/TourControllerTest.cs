using Velosaurus.Api.Controllers;

namespace Velosaurus.Api.Test;

public class TourControllerTest
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

        Assert.That(result, Is.EqualTo("Hello There =)"));
    }
}