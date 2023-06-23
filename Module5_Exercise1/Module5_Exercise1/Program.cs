﻿using Module5_Exercise1.DogsApiExample;
using System.Threading.Tasks;
using Module5_Exercise1.ReqresApiExample;

namespace Module5_Exercise1;

internal class Program
{
    internal static async Task Main(string[] args)
    {
        await GoogleHttpExample.GooglePageExampleAsync();

        await ReqresApi.ReqresModelsExampleAsync();
        
        await ReqresApi.ReqresPostExampleAsync();
        
        await DogsApi.DownloadDogAsync();
    }
}
