namespace ABU.CanvasSharp.Core.Constants;

public static class CanvasResource
{
    public const string BaseUrl = "https://canvas.instructure.com";
    public const string Courses = "/api/v1/courses";
    /// <summary>
    /// A list of scopes that can be applied to developer keys and access tokens.
    /// Requires account id in placeholder {0}.
    /// </summary>
    public const string Scopes = "/api/v1/accounts/{0}/scopes";
    /// <summary>
    /// Returns a list of all global notifications in the account for the current user Any notifications
    /// that have been closed by the user will not be returned, unless a include_past parameter is passed in as true.
    /// Requires account id in placeholder {0}.
    /// </summary>
    public const string Notifications = "/api/v1/accounts/{0}/account_notifications";
}