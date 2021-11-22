using ABU.CanvasSharp.Core.Constants;
using ABU.CanvasSharp.Infrastructure.Abstractions;
using Ardalis.GuardClauses;
using RestSharp;
using RestSharp.Authenticators;

namespace ABU.CanvasSharp.Infrastructure.Services;

public class CanvasApiClient : ICanvasApiClient
{
    private readonly IRestClient _client;

    public CanvasApiClient(IRestClient client, IConfiguration configuration)
    {
        _client = Guard.Against.Null(client, nameof(client));
        var config = Guard.Against.Null(configuration, nameof(configuration));

        _client.BaseUrl = new Uri(CanvasRoutes.BaseUrl);
        _client.Authenticator = new JwtAuthenticator(config["CanvasToken"]);
    }

    public async Task<string> GetCoursesAsync(CancellationToken ct = default)
    {
        var request = new RestRequest(
            string.Format(CanvasRoutes.Courses), Method.GET, DataFormat.Json
        ) as IRestRequest;
        
        var response = await _client.ExecuteGetAsync(request, ct);

        if (!response.IsSuccessful)
            return string.Empty;

        return response.Content;
    }
}