using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookStore.API.Domain.Models;

public  class Specification
{
    [JsonPropertyName("Originally Published")]
    public string? OriginallyPublished { get; set; }

    public string? Author { get; set; }

    [JsonPropertyName("Page Count")]
    public int PageCount { get; set; }

    public JsonElement Illustrator { get; set; } 

    public JsonElement Genres { get; set; }
    
    [System.Text.Json.Serialization.JsonIgnore]
    public string GeneresContent { get; set; } = string.Empty;

    [System.Text.Json.Serialization.JsonIgnore]
    public string IllustratorContent { get; set; } = string.Empty;

}

