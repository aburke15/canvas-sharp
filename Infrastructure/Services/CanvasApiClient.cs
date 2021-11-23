using ABU.CanvasSharp.Core.Constants;
using ABU.CanvasSharp.Infrastructure.Abstractions;
using Ardalis.GuardClauses;
using RestSharp;
using RestSharp.Authenticators;

namespace ABU.CanvasSharp.Infrastructure.Services;

public class CanvasApiClient : ICanvasApiClient
{
    private readonly IRestClient _client;

    public CanvasApiClient(IRestClient client) 
        => _client = Guard.Against.Null(client, nameof(client));

    public async Task<string> GetCoursesAsync(CancellationToken ct = default)
    {
        var request = new RestRequest(
            CanvasResource.Courses, DataFormat.Json
        ) as IRestRequest;
        
        var response = await _client.ExecuteGetAsync(request, ct);

        if (!response.IsSuccessful)
            return string.Empty;

        return response.Content;
    }
}