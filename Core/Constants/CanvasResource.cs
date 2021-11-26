namespace ABU.CanvasSharp.Core.Constants;

public static class CanvasResource
{
    public const string BaseUrl = "https://canvas.instructure.com";
    public const string Courses = "/api/v1/courses";
    /// <summary>
    /// A list of scopes that can be applied to developer keys and access tokens.
    /// Requires account id.
    /// </summary>
    public const string Scopes = "/api/v1/accounts/{0}/scopes";
}