namespace Velosaurus.Core.Exceptions;

public class VelosaurusBaseException : Exception
{
    public string? ExceptionTitle { get; protected set; }
    public string? ExceptionDetail { get; protected set; }
    public string? ExceptionType { get; protected set; }
}