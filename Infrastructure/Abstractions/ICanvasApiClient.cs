namespace ABU.CanvasSharp.Infrastructure.Abstractions;

public interface ICanvasApiClient
{
    Task<string> GetCoursesAsync(CancellationToken ct = default);
}