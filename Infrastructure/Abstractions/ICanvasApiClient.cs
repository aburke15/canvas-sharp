using ABU.CanvasSharp.Core.Models;

namespace ABU.CanvasSharp.Infrastructure.Abstractions;

public interface ICanvasApiClient
{
    Task<IReadOnlyList<Course>> GetCoursesAsync(CancellationToken ct = default);
    Task<string> GetScopesAsync(CancellationToken ct = default);
    Task<string> GetNotificationsAsync(long accountId, bool includePast = false, CancellationToken ct = default);
    Task CreateNotificationAsync(long accountId, CancellationToken ct = default);
}