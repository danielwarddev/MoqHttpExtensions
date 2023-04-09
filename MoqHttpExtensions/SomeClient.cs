using System.Net.Http.Json;

namespace MoqHttpExtensions;

public class SomeClient
{
    private readonly HttpClient _httpClient;

    public SomeClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> AddOneToResponseResult()
    {
        var responseValue = await _httpClient.GetFromJsonAsync<int>("myEndpoint");
        return responseValue + 1;
    }
}
