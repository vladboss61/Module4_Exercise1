using Newtonsoft.Json;

namespace Module4_Exercise1.ReqresApiExample.Models;

internal sealed class ReqresUserRequest
{
    public int Id { get; set; }

    public string Email { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    public string Avatar { get; set; }
}
