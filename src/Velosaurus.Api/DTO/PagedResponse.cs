using System.Text.Json.Serialization;

namespace Velosaurus.Api.DTO;

public class PagedResponse<T>
{
    [JsonInclude]
    List<T> Items { get; set; }

    [JsonInclude]
    PaginationMetadata PaginationMetadata { get; set; }

    public PagedResponse(List<T> items, PaginationMetadata paginationMetadata)
    {
        Items = items;
        PaginationMetadata = paginationMetadata;
    }
}
