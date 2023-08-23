using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace Module4_Exercise1;

internal static class GoogleHttpExample
{
    private const string GoogleURL = "https://www.google.com/";

    public static async Task GooglePageExampleAsync()
    {
        using var client = new HttpClient();
        HttpResponseMessage result = await client.GetAsync(GoogleURL);

        if (result.StatusCode == HttpStatusCode.OK)
        {
            Console.WriteLine("Ok Code from google.com");
            string content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }
}
