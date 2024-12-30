using System.Text.Json.Serialization;

namespace Velosaurus.Api.DTO;

public class PagedResponse<T>
{
    [JsonInclude]
    private List<T> Items { get; set; }

    [JsonInclude]
    private PaginationMetadata PaginationMetadata { get; set; }

    public PagedResponse(List<T> items, PaginationMetadata paginationMetadata)
    {
        Items = items;
        PaginationMetadata = paginationMetadata;
    }
}
