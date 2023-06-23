using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5_Exercise1.DogsApiExample.Models;

internal sealed class DogResponse
{
    public string Status { get; set; }

    public string Message { get; set; }

    public override string ToString()
    {
        return $"Status: {Status}, Message: {Message}";
    }
}
