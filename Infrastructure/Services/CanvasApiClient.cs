using System.Web;
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

    public async Task<string> GetScopesAsync(CancellationToken ct = default)
    {
        var request = new RestRequest(
            string.Format(CanvasResource.Scopes, "20000000000014"), DataFormat.Json
        ) as IRestRequest;
        
        var response = await _client.ExecuteGetAsync(request, ct);
        var scopes = response.Content;

        if (!response.IsSuccessful) return string.Empty;

        return scopes;
    }

    public async Task<string> GetNotificationsAsync(long accountId, bool includePast = false, CancellationToken ct = default)
    {
        var resource = string.Format(CanvasResource.Notifications, $"{accountId}");
        if (includePast)
            resource += $"?include_past={includePast}";
        
        var request = new RestRequest(
            resource, DataFormat.Json
        ) as IRestRequest;

        var response = await _client.ExecuteGetAsync(request, ct);

        if (!response.IsSuccessful) 
            return string.Empty;

        var notifications = response.Content;

        return notifications;
    }

    public async Task CreateNotificationAsync(long accountId, CancellationToken ct = default)
    {
        var longUrl = string.Concat(_client.BaseUrl?.ToString(), string.Format(CanvasResource.Notifications, accountId));
        var uriBuilder = new UriBuilder(longUrl);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        query["subject"] = "Hi GF.";
        query["message"] = "This is from your BF.";
        query["start_at"] = DateTime.Now.AddMinutes(5).ToString("yyyy-MM-ddTHH:mm:ssZ");
        query["end_at"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddTHH:mm:ssZ");

        var queryString = query.ToString();
        uriBuilder.Query = queryString;
        longUrl = uriBuilder.ToString();

        var resource = string.Concat(string.Format(CanvasResource.Notifications, accountId), "?", queryString);
        
        var request = new RestRequest(
            resource, DataFormat.Json
        ) as IRestRequest;

        var response = await _client.ExecutePostAsync(request, ct);
    }
}