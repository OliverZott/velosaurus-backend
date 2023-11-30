using Microsoft.AspNetCore.Mvc;

namespace Velosaurus.Core.ResponseObjects;

public class VelosaurusProblemDetails : ProblemDetails
{
    public VelosaurusProblemDetails()
    {
        Status = 404;
        Title = "";
        Detail = "";
        Instance = "";
    }
}