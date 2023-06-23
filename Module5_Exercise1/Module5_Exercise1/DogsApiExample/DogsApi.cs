using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Module5_Exercise1.DogsApiExample.Models;

namespace Module5_Exercise1.DogsApiExample;

internal static class DogsApi
{
    private const string DogsURL = "https://dog.ceo/api/breeds/image/random";

    public static async Task DownloadDogAsync()
    {
        using var httpClient = new HttpClient();
        HttpResponseMessage dogResponseMessage = await httpClient.GetAsync(DogsURL);

        if (dogResponseMessage.StatusCode == HttpStatusCode.OK)
        {
            string dogString = await dogResponseMessage.Content.ReadAsStringAsync();
            DogResponse dogResponse = JsonSerializer.Deserialize<DogResponse>(dogString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Console.WriteLine(dogResponse.ToString());

            HttpResponseMessage imageResponseMessage = await httpClient.GetAsync(dogResponse.Message);

            if (imageResponseMessage.IsSuccessStatusCode)
            {
                Stream contentStream = await imageResponseMessage.Content.ReadAsStreamAsync();

                var fileName = dogResponse.Message.Split("/").LastOrDefault();

                if (fileName is null)
                {
                    return;
                }

                await using var file = File.Create(fileName);

                await contentStream.CopyToAsync(file);

                await file.FlushAsync();

                Console.WriteLine("File with dog is downloaded, check its.");
            }
        }
    }
}
