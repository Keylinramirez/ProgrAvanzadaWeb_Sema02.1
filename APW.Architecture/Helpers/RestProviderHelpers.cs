using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APW.Architecture.Helpers;

internal static class HttpProviderExtentions
{
    private static void AddDefaultRequestHeader(this HttpClient client, string name, string value)
    {
        var defaultHeaders = client.DefaultRequestHeaders;
        if (defaultHeaders.Contains(name))
            defaultHeaders.Remove(name);
        defaultHeaders.Add(name, value);
    }
}

internal static class RestProviderHelpers
{
    internal static HttpClient CreateHttpClient(string endpoint)
    {
        var client = new HttpClient { BaseAddress = new Uri(endpoint) };
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return client;
    }

    internal static StringContent CreateContent(string content) => new(content, Encoding.UTF8, "application/json");

    internal static async Task<string> GetResponse(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    internal static Exception ThrowError(string endpoint, Exception ex) => new ApplicationException($"Error getting data from {endpoint}", ex);
}
