using Velosaurus.Api.Controllers;

namespace Velosaurus.Api.Test;

public class ActivityControllerTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Hello_AllWorking_ReturnsHelloHtml()
    {
        var testController = new TestController();

        var result = testController.Hello();
        Assert.Multiple(() =>
        {
            Assert.That(result.ContentType, Is.EqualTo("text/html"));
            Assert.That(result.Content, Does.Contain("Hello There"));
            Assert.That(result.Content, Does.Contain("/api/v1/activity"));
        });
    }
}