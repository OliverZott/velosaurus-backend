namespace Velosaurus.Core.Exceptions;

public class ItemNotFoundException : VelosaurusBaseException
{
    public ItemNotFoundException(string type, int id)
    {
        ItemId = id;
        ItemType = type;
        ExceptionTitle = "Item Not Found.";
        ExceptionDetail = $"No {type} item found with id {id}.";
        ExceptionType = "https://tools.ietf.org/html/rfc7231#section-6.5.4";
    }

    public int ItemId { get; protected set; }
    public string ItemType { get; protected set; }
}
