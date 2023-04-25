using Microsoft.AspNetCore.Server.IIS.Core;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookStore.API.Domain.Models;

public class Book
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; } 
    public double ValorFrete { get; set; }
    public Specification? Specifications { get; set; }



    public string WriteArrayOrString(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Array)
        {
            var list = element.Deserialize<List<string>>();
            return string.Join(", ", list!);
        }
        else
        {
            return element.ToString();
            //  b.Specifications.GeneresContent = element.ToString();
        }
    }

}