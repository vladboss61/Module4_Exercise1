﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Module5_Exercise1.ReqresApiExample.Models;

namespace Module5_Exercise1.ReqresApiExample;

internal static class ReqresApi
{
    private const string RequesURL = "https://reqres.in/";

    public static async Task ReqresModelsExampleAsync()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(RequesURL);

        HttpResponseMessage result = await client.GetAsync("api/users?page=2");

        if (result.StatusCode == HttpStatusCode.OK)
        {
            Console.WriteLine("Ok Code from reqres site.");
            string content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            ReqresPageRequest pageRequest = JsonConvert.DeserializeObject<ReqresPageRequest>(content);

            if (pageRequest is not null)
            {
                Console.WriteLine(pageRequest.ToString());
            }
        }
    }

    public static async Task ReqresPostExampleAsync()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(RequesURL);

        var userParametersRequest = new CreateUserParametersRequest
        {
            Name = "Vlad",
            Job = "Software Engineer"
        };

        string serializedUser = JsonConvert.SerializeObject(userParametersRequest);
        var stringContent = new StringContent(serializedUser, Encoding.Unicode, "application/json"); // application/json - required.

        HttpResponseMessage result = await client.PostAsync("api/users", stringContent);

        if (result.StatusCode == HttpStatusCode.Created)
        {
            Console.WriteLine("StatusCode Created");

            string content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);

            UserCreatedResponse userCreatedResponse = JsonConvert.DeserializeObject<UserCreatedResponse>(content);
            Console.WriteLine(userCreatedResponse!.Name);
        }
    }
}
