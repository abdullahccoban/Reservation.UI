using System.Text;
using Newtonsoft.Json;

namespace Reservation.UI.Repositories.Base;

public abstract class ApiClientBase
{
    private readonly HttpClient _httpClient;

    public ApiClientBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest request)
        where TRequest : class
        where TResponse : class
    {
        string? jsonPayload = JsonSerialize<TRequest>(request);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
        HttpResponseMessage? response = null;
        
        try
        {
            response = await _httpClient.PostAsync(url, content);
        }
        catch (HttpRequestException ex)
        {
            throw new HttpRequestException();
        }

        if (!response.IsSuccessStatusCode) return null;
        
        var responseString = await response.Content.ReadAsStringAsync();
        if (!string.IsNullOrWhiteSpace(responseString)) 
            return JsonDeserialize<TResponse>(responseString);

        return null;
    }

    protected async Task<TResponse?> GetAsync<TResponse>(string url, Dictionary<string, string>? headers = null)
        where TResponse : class
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, url);

        if (headers is not null)
        {
            foreach (var (key, value) in headers)
            {
                request.Headers.Remove(key);
                request.Headers.Add(key, value);
            }
        }
        
        HttpResponseMessage? response = null;
        
        try
        {
            response = await _httpClient.SendAsync(request);
        }
        catch (HttpRequestException ex)
        {
            throw new HttpRequestException(ex.Message);
        }

        if (!response.IsSuccessStatusCode) 
            return null;
        
        var responseString = await response.Content.ReadAsStringAsync();
        
        if (string.IsNullOrWhiteSpace(responseString)) 
            return null;
        
        return JsonDeserialize<TResponse>(responseString);
    }

    private string JsonSerialize<TRequest>(TRequest request)
    {
        try
        {
            return JsonConvert.SerializeObject(request);
        }
        catch (JsonException ex)
        {
            throw new JsonException(ex.Message);
        }
    }

    private TResponse? JsonDeserialize<TResponse>(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<TResponse>(json);
        }
        catch (JsonException ex)
        {
            throw new JsonException(ex.Message);
        }
    }
}