using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class HttpClientHelper
{
    private static readonly HttpClient client = new HttpClient();
    private static readonly int year = 2023;
    private static string baseUrl = $"https://api.census.gov/data/{year}/acs/acs1";
    

    /// <summary>
    /// Get income details.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public async Task<string> GetAsync(string filter, int year = 2023)
    {
        baseUrl = string.Format(baseUrl, year);
        var url = baseUrl + filter;
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            return null;
        }
    }
}
