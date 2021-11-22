using RestSharp;

namespace ABU.CanvasSharp.Infrastructure.Services;

public class CanvasApiClient
{
    private readonly IRestClient _client;
    
    public CanvasApiClient(IRestClient client)
    {
        _client = client;
    }
}