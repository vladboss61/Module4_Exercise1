using Newtonsoft.Json;
using System.Collections.Generic;

namespace Module4_Exercise1.ReqresApiExample.Models;

internal sealed class ReqresPageResponse
{
    public int Page { get; set; }

    [JsonProperty("per_page")]
    public int PerPage { get; set; }

    public int Total { get; set; }

    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }

    public ICollection<ReqresUserRequest> Data { get; set; }

    public override string ToString()
    {
        return $"Page: {Page} | PerPage: {PerPage} | Total: {Total} | TotalPages: {TotalPages}";
    }
}
