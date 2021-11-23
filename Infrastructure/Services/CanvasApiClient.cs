using ABU.CanvasSharp.Core.Constants;
using ABU.CanvasSharp.Core.Models;
using ABU.CanvasSharp.Infrastructure.Abstractions;
using Ardalis.GuardClauses;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace ABU.CanvasSharp.Infrastructure.Services;

public class CanvasApiClient : ICanvasApiClient
{
    private readonly IRestClient _client;

    public CanvasApiClient(IRestClient client) 
        => _client = Guard.Against.Null(client, nameof(client));

    public async Task<IReadOnlyList<Course>> GetCoursesAsync(CancellationToken ct = default)
    {
        var request = new RestRequest(
            CanvasResource.Courses, DataFormat.Json
        ) as IRestRequest;
        
        var response = await _client.ExecuteGetAsync(request, ct);
        var courses = JsonConvert.DeserializeObject<IReadOnlyList<Course>>(response.Content);

        if (!response.IsSuccessful || courses is null || courses.Count == 0)
            return new List<Course>();

        return courses;
    }
}